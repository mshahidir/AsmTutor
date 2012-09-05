SECTION .data
hw:	db	"Hello World",10
hwlen:	equ	$ - hw

SECTION .text
	mov eax, 01
	int 80h
;Your code goes here

