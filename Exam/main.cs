using System;
using static System.Console;
using static System.Math;

class main{
static void Main(){
	int n = 6;
	var rnd = new Random(1);
	var A = new matrix(n,n);
	for( int i=0;i<A.size1;i++)
		for( int j=i;j<A.size2;j++){
			A[i,j]=A[j,i]=rnd.NextDouble();
		}
	A.print("A=");
	//var Q = new matrix(A.size1,A.size2);
	//Q.set_identity();
	//Q[0,3] = 383;
	//Q.print("Q=");
	//for(int k=0; k<A.size2;k++){
	//	var a = Q[0,k];
	//	Write($"{a} ");
	//}

	var D = A.copy();
	var (H,V) = jacobi.hessenberg(D);
	D.print("D=");
	H.print("H=");
	V.print("V=");
}
}
