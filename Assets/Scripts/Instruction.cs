// using System.Collections;
// using System.Collections.Generic;

// public enum InstructionName{
// 	NOOP
// 	// Listar todas as instruções
// }

// public enum States {
// 	Fetch,
// 	Decode,
// 	Execute,
// 	Memory,
// 	Writeback
// }

// public class Instruction {

// 	public InstructionName name;
// 	public bool[] states;

// 	public Instruction(){
// 		this.states = new bool[Enum.GetNames(typeof(States)).Length];
// 	}

// 	public Instruction(bool[] states){
// 		if(states.Length != Enum.GetNames(typeof(States)).Length)
// 			throw InvalidArgumentException();

// 		this.states = states;
// 	}
// }
