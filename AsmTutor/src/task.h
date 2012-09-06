#ifndef TASK_H_INCLUDED
#define TASK_H_INCLUDED
#include <glib.h>
#include "asmtutor.h"

#define question (gchar*) \
	"#include <stdio.h>\n" \
	"\n" \
	"/""* Rewrite this code in x86 intel assembler, but without using the \n" \
	"standard c library (libc) */\n" \
	"int main(int argc, char *argv[]) {\n" \
	"    puts(\"Hello World\");\n" \
	"    return 0;\n" \
	"}"

#define answer (gchar *) \
	"SECTION .data\n" \
	"hw:	db	\"Hello World\",10\n" \
	"hwlen:	equ	$ - hw\n\n" \
	"SECTION .text\n" \
	"global _start\n" \
	"_start:\n" \
	"	;Your code goes here\n"

#define correct (char *) \
	"Hello World\n"

#define assembler_command \
	"nasm -f elf32 -o %s %s" \
	STDERR_REDIRECT

#define linker_command \
	"ld -melf_i386 -Bshareable -pie -o %s -dynamic-linker "\
	"/usr/lib/ld-linux.so.2 %s" \
	STDERR_REDIRECT

#define passwd \
	"WhipThatAss"

#endif // TASK_H_INCLUDED
