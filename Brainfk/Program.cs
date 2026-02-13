// Brainfuck interpreter

Main();
return;

void Main()
{
    var tape = new byte[30000];
    var ptr = 0;
    const string code = "++++++++[>++++[>++>+++>+++>+<<<<-]>+>+>->>+[<]<-]>>.>---.+++++++..+++.>>.<-.<.+++.------.--------.>>+.>++."; // Hello World!
    // start interpreter
    for (var i = 0; i < code.Length; i++)
    {
        var command = code[i];
        switch (command)
        {
            case '>': ptr++; break;
            case '<': ptr--; break;
            case '+': tape[ptr]++; break;
            case '-': tape[ptr]--; break;
            case '.': Console.Write((char)tape[ptr]); break;
            case ',': tape[ptr] = (byte)Console.Read(); break;
            case '[':
                if (tape[ptr] == 0)
                {
                    var loopCounter = 1;
                    while (loopCounter > 0)
                    {
                        i++;
                        switch (code[i])
                        {
                            case '[':
                                loopCounter++;
                                break;
                            case ']':
                                loopCounter--;
                                break;
                        }
                    }
                }
                break;
            case ']':
                if (tape[ptr] != 0)
                {
                    var loopCounter = 1;
                    while (loopCounter > 0)
                    {
                        i--;
                        switch (code[i])
                        {
                            case ']':
                                loopCounter++;
                                break;
                            case '[':
                                loopCounter--;
                                break;
                        }
                    }
                }
                break;
        }
    }
}