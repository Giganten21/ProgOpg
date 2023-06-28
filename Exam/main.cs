using System;
using static System.Console;
using static System.Math;
using System.Diagnostics;

class main{
static void Main(){
	var rand = new Random();
	int n = rand.Next(3,8);
	//int n = 6;
	var rnd = new Random(n);
	var A = new matrix(n,n);
	for( int i=0;i<A.size1;i++)
		for( int j=i;j<A.size2;j++){
			A[i,j]=A[j,i]=rnd.NextDouble();
		}
	WriteLine("########Hessenberg factorization of a real square matrix using Jacobi transformations########");
	WriteLine("Making a symmetric matrix A of random size between 3x3 and 8x8");
	A.print("A=");
	Stopwatch watch = new Stopwatch();
	watch.Start();
	var (H,Q) = jacobi.hessenberg(A);
	watch.Stop();
	WriteLine($"The Hessenberg factorization took {watch.Elapsed.TotalSeconds} seconds.");
	WriteLine("The comupted matrices H(lower hessenberg) and Q(trandformations):");
	H.print("H=");
	Q.print("Q=");
	WriteLine("\n########Checking identies given is the exercise########");
	WriteLine("Checking A = QHQ.T");
	var QHQT = Q*H*Q.T;
	QHQT.print("QHQT=");
	var QTQ = Q.T*Q;
	QTQ.print("Calculating QT*Q which should be equal to I");
	WriteLine("Since this is furfilled H must be the lower Hessenberg form of the matrix A");
	WriteLine("\n########Extra########");
	WriteLine("The time of the Hessenberg vs. the QR is ploted in Compare.svg, and shows that QR is faster by about a factor 2.");
	var det = jacobi.det(H);
	WriteLine("\nFinding the determinant");
	WriteLine($"Determinant = {det}");

}
}
