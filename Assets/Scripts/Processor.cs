using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// public class NamedArrayAttribute : PropertyAttribute {
	// public readonly string[] names;
	// public NamedArrayAttribute(string[] names) { this.names = names; }
// }

[UnityEngine.SerializeField]
public class Processor : MonoBehaviour {

	public static readonly int MEM_SIZE = 25;

	/* Editor variables */
	[UnityEngine.SerializeField] private Text help;
	[UnityEngine.SerializeField] private Text list;
	private bool helpEnabled;
	private bool listEnabled;
	private int ncount;

	/* Serializable variables so we can edit and see them in Unity Editor */
	public string[] code = new string[MEM_SIZE];
	
	// [NamedArrayAttribute (new string[] {"Fetch", "Decode", "Execute", "Memory", "Writeback"})]
	public string[] pipestr;

	// Instruction array constructor intialize to NOOP
	public Instruction[] pipeline;
	public int[] registerBank = new int[4];
	public int[] dataMemory = new int[MEM_SIZE]; 	// Memory is word oriented
	public List<Instruction> instructionMemory; 	// Memory is word oriented

	// Processor registers and flags
	public bool halted = false;
	public int pc = 0;
	public int branchPc = 0;
	public int regA = 0, regB = 0;
	public int regO0 = 0;
	public int regO1 = 0;
	public int writeToMem = 0;

	// Graphical game objects
	public MuxController pcMux;
	public RegisterController pcReg;
	public RegisterController A, B;
	public RegisterController O0, O1;
	public RegisterFileController regFile;
	public UlaController ula;
	public InputField getInstr;
	public MemoryPanelController instrMem, dataMem;

	void Start() {
		instructionMemory = new List<Instruction>();
		pipeline = new Instruction[5];
		ClearPipeline();
		helpEnabled = true;
		listEnabled = true;
		ncount = 0;

		getInstr.onEndEdit.AddListener(delegate { AddInstruction(getInstr); });
	}

	void Update() {

		regFile.setValues(registerBank);
		ula.setInputA(regA);
		ula.setInputB(regB);
		ula.setOutput(regO0);
		pcReg.setValue(pc);
		A.setValue(regA);
		B.setValue(regB);
		O0.setValue(regO0);
		O1.setValue(regO1);

		if(Input.GetKeyDown("h")) { 
			helpEnabled = !helpEnabled;
			this.help.gameObject.SetActive(helpEnabled);
		}
		if(Input.GetKeyDown("l")) { 
			listEnabled = !listEnabled;
			this.list.gameObject.SetActive(listEnabled);
		}

		if(Input.GetKeyDown("n") && !halted) {
			ncount = 1;
			pcMux.SetInput(pc+1, pipeline[1].op3, regB);
			NextStep();
			pcMux.SetOutput(pc);
		}
		
		if(Input.GetKey("n") && ncount++%10 == 0 && !halted) {

			pcMux.SetInput(pc+1, pipeline[1].op3, regB);
			NextStep();
			pcMux.SetOutput(pc);
		}
	}

	void NextStep() {
		
		Instruction instr;
		try {
	    	instr = instructionMemory[this.pc];
	    	pipestr[0] = instr.icode;
    	} catch {
    		instr = new Instruction();
    		pipestr[0] = instr.icode;
    	}

		for(int i = 4; i > 0; i--) { // Move pipeline forward
			pipeline[i] = pipeline[i-1];
			pipestr[i] = pipeline[i].icode;
		}
		pipestr[0] = pipeline[0].icode;

		InstructionWriteback(pipeline[4], regO1);
		InstructionMemory(pipeline[3], regO0, writeToMem, ref regO1);
		InstructionExec(pipeline[2], regA, regB, ref regO0);
		InstructionDecode(pipeline[1], ref regA, ref regB);
		InstructionFetch(pc, ref pipeline[0]);
		
		// Avoid Writeback directly writing to register bank and screwing up
		// Fetch register bank
		// registerBank = (int[]) tmpBank.Clone(); 
	}

	/* Pipeline units */
    public void InstructionFetch(int address, 
    	ref Instruction instr) {

		try {
			instr = instructionMemory[this.pc++];
			pipestr[0] = instr.icode;
		} catch {
			instr = new Instruction();
			pipestr[0] = instr.icode;
		}
	}

	public void InstructionDecode(Instruction instr, 
		ref int outputA, ref int outputB) {

		switch(instr.type) {
		// R
		case 'R':
			// op1 is the destiny register
			outputA = this.registerBank[instr.op2]; // First operand
			outputB = this.registerBank[instr.op3]; // Second operand
			break;

		// Index
		case 'I':
			// op1 is the destiny register or is not used
			outputA = this.registerBank[instr.op2]; // Get value from register
			outputB = instr.op3;					// Immediate
			break;
		
		// JUMP
		case 'J':
			pc = instr.op3-1; // Immediate
			ClearPipeline();
			break;
		
		// NOOP
		case 'N':
			break;
		}
	}

	public void InstructionExec(Instruction instr, int inputA, int inputB, 
		ref int output) {

		switch(instr.iname) {

		// NOOP
		case "NOOP":
			break;
		case "HALT":
			halted = true;
			break;
			
		case "SW":
			this.writeToMem = registerBank[instr.op1]; // This works?
			output = inputA + inputB;
			break;

		case "LW":
		case "ADD":
		case "ADDI":
			output = inputA + inputB;
			break;

		case "SUB":
		case "SUBI":
			output = inputA - inputB;
			break;

		case "MULT":
		case "MULTI":
			output = inputA * inputB;
			break;

		case "DIV":
		case "DIVI":
			output = inputA / inputB;
			break;

		case "AND":
		case "ANDI":
			output = inputA & inputB;
			break;

		case "OR":
		case "ORI":
			output = inputA | inputB;
			break;

		case "XOR":
		case "XORI":
			output = inputA ^ inputB;
			break;

		case "SLL":
		case "SLLI":
			output = inputA << inputB;
			break;

		case "SRL":
		case "SRLI":
			output = inputA >> inputB;
			break;

		case "BEZ":
			if(inputA == 0) {
				pc = inputB-1;
				// ClearPipeline();
			}
			break;

		case "BNZ":
			if(inputA != 0) {
				pc = inputB-1;
				// ClearPipeline();
			}
			break;
		
		case "JMP":
			// Jump have already jumped at Decode stage
			break;
		}
	}

	public void InstructionMemory(Instruction instr, int address, int memWriteD, 
		ref int memReadD) {

		// RegO1 = RegO0 (reaproveitando os mesmos registradores)
		memReadD = address;

		if(instr.iname.Equals("LW"))
			memReadD = dataMemory[address];
		else if(instr.iname.Equals("SW")){
			dataMemory[address] = memWriteD;
			dataMem.setValue(address, memWriteD.ToString());
		}
	}

	public void InstructionWriteback(Instruction instr, int input) {
		// Dont write to register bank if instruction doesnt have WB stage
		// Instruction that dont write to register bank:
		// NOOP JMP BRANCH0 BRANCH!0 STORE
		if( instr.type != 'J' && 
			instr.type != 'N' && 
		   !instr.iname.Equals("BEZ") && 
		   !instr.iname.Equals("BNZ") && 
		   !instr.iname.Equals("SW"))
				
			registerBank[instr.op1] = input;
	}

	/* End pipeline units */

	public void ClearPipeline() {
		CodeStringToInstructionMemory();

		for(int i = 0; i < 5; i++) {
			pipeline[i] = new Instruction();
			pipestr[i] = pipeline[i].icode;
		}
	}

	public void CodeStringToInstructionMemory() {
		instructionMemory = new List<Instruction>();
    	for(int i = 0; i < code.Length; i++){
      		instructionMemory.Add(new Instruction(code[i]));
      		instrMem.setValue(i, code[i]);
    	}
  	}

	public void AddInstruction(InputField addInstr) {
		string[] tmp;
		
		if(addInstr.textComponent.text.Length <= 0)
			return; 

		tmp = addInstr.textComponent.text.Split(':');
		
		try {
			code[Int32.Parse(tmp[0])] = tmp[1];
			CodeStringToInstructionMemory();
		} catch {
			Debug.Log("U DENSE MOTHER FUCKER");
		}

		addInstr.textComponent.text = "";
	}
}
