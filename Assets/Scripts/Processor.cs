using System.Collections;
using System.Collections.Generic;

public class Processor {

	public int[] registerBank = new int[4];
	public List<Instruction> instructionMemory;

	private FetchUnit fu;
    private IFId ifId;
    private Decode decode;
    private IdEx idEx;
    private Execute execute;
    private ExMem exMem;
    private Memory memory;
    private MemWb memWb;
    private WriteBack writeBack;

}