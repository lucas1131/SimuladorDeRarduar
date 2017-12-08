using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction {
	
	// Instruction code separator
	public static readonly char[] SEPARATOR = {' '};
	public static readonly string NOOP = "NOOP - - -";
	// MIPS Instruction Set for this simulation
	public static readonly Dictionary<string, char> InstructionSet = 
		new Dictionary<string, char>{
			{ "NOOP", 	'N' },
			{ "HALT", 	'N' },
			
			{ "ADD",	'R' },
			{ "SUB",	'R' },
			{ "MULT",	'R' },
			{ "DIV",	'R' },
			{ "AND",	'R' },
			{ "OR",		'R' },
			{ "XOR", 	'R' },
			{ "SLL", 	'R' },
			{ "SRL", 	'R' },
			
			{ "LW", 	'I' },
			{ "SW", 	'I' },
			{ "BEZ", 	'I' },
			{ "BNZ", 	'I' },
			{ "ADDI", 	'I' },
			{ "SUBI", 	'I' },
			{ "MULTI", 	'I' },
			{ "DIVI", 	'I' },
			{ "ANDI", 	'I' },
			{ "ORI", 	'I' },
			{ "XORI", 	'I' },
			{ "SLLI", 	'I' },
			{ "SRLI", 	'I' },

			{ "JMP", 	'J' }
	    };

	// Object attributes
	public string icode { get; private set; }	// Instruction in format "add r0 r1 r2"

	public string iname	{ get; private set; }	// Instruction name as in "add"
	public char type 	{ get; private set; }
	public int op1		{ get; private set; }	// Instruction first operand "r0"
	public int op2		{ get; private set; }	// Instruction second operand "r1"
	public int op3		{ get; private set; }	// Instruction third operand "r2"


	// 0-argument constructor for array creation
	public Instruction(){
		this.icode = NOOP;
		this.Parse(NOOP);
		this.type = Instruction.InstructionSet[this.iname];
	}

	public Instruction(string icode){
		icode = icode.ToUpper();
		this.icode = icode;


		this.Parse(icode);
		this.type = Instruction.InstructionSet[this.iname];
	}

	private void Parse(string icode){
		
		Debug.Log(icode);
		
		string[] parts = icode.Split(SEPARATOR);
		this.iname = parts[0];

		// if(parts[1][0] == '-') // Value doesnt exist in instruction
		// 	this.op1 = null;
		if(parts[1][0] == 'R') // Differentiate register from immediate value
			this.op1 = parts[1][1] - '0';
		else if(parts[1][0] != '-') // Immediate value
			this.op1 = Int32.Parse(parts[1]);

		// if(parts[2][0] == '-') // Value doesnt exist in instruction
		// 	this.op2 = null;
		if(parts[2][0] == 'R') // Differentiate register from immediate value
			this.op2 = parts[2][1] - '0';
		else if(parts[2][0] != '-') // Immediate value
			this.op2 = Int32.Parse(parts[2]);

		// if(parts[3][0] == '-') // Value doesnt exist in instruction
		// 	this.op3 = null;
		if(parts[3][0] == 'R') // Differentiate register from immediate value
			this.op3 = parts[3][1] - '0';
		else if(parts[3][0] != '-') // Immediate value
			this.op3 = Int32.Parse(parts[3]);
	}
}