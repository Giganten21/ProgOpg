using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

class main{
static void Main(){
	var rand = new Random();
	int n = rand.Next(3,8);
	var rnd = new Random(n);
	var A = new matrix(n,n);
	for( int i=0;i<A.size1;i++)
		for( int j=i;j<A.size2;j++){
			A[i,j]=A[j,i]=rnd.NextDouble();
		}
	A.print("A=");
	Stopwatch watch = new Stopwatch();
	watch.Start();
	var (H,Q) = jacobi.hessenberg(A);
	watch.Stop();
	WriteLine($"The Hessenberg factorization took {watch.Elapsed.TotalSeconds} seconds.");
	H.print("H=");
	Q.print("Q=");
	
	WriteLine("Checking A = QHQ.T");
	var QHQT = Q*H*Q.T;
	QHQT.print("QHQT=");
	var QTQ = Q.T*Q;
	QTQ.print("This should be equal to the identity matrix:");
	WriteLine("Since this is furfilled H must be the lower Hessenberg form of the matrix A");
	var det = jacobi.det(H);
	WriteLine($"Determinant = {det}");

}
}
