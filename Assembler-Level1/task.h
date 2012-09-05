#ifndef TASK_H_INCLUDED
#define TASK_H_INCLUDED
#include <glib.h>

gchar * question  = "#include <stdio.h>\n"
                    "\n"
                    "int main(int argc, char *argv[]) {\n"
                    "/* This is the code you are trying to model in asm */\n"
                    "    puts(\"Hello World\");\n"
                    "    return 0;\n"
                    "}";

gchar * answer    = "SECTION .data\n"
                    "hw:	db	\"Hello World\",10\n"
                    "hwlen:	equ	$ - hw\n\n"
                    "SECTION .text\n"
                    ";Your code goes here\n";

#endif // TASK_H_INCLUDED
