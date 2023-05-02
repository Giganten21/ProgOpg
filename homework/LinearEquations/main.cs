using System;
using static System.Console;
using static System.Math;

class main{

static void Main(string[] args){
	int n=6,m=2;
	matrix A = new matrix(n,m);
	matrix R = new matrix(m,m);
	var rnd = new Random(1);
	for(int i=0;i<n;i++)
		for(int j=0;j<m;j++)A[i,j]=rnd.NextDouble();
	matrix Q=A.copy();
	QRGS.decomp(Q,R);
	WriteLine("Part A)");
	A.print("A=");
	Q.print("Q=");
	R.print("R=");
	var QTQ = Q.T * Q;
	QTQ.print("QTQ=");
	var QR = Q*R;
	QR.print("QR=");


	int o=4;
	matrix A1 = new matrix(o,o);
	matrix R1 = new matrix(o,o);
	vector b = new vector(o);
	for(int i=0;i<o;i++)
		for(int j=0;j<o;j++)A1[i,j]=rnd.NextDouble();
	
	for(int i=0;i<o;i++)b[i]=i*4;

	matrix Q1 = A1.copy();
	QRGS.decomp(Q1,R1);
	A1.print("A=");
	Q1.print("Q=");
	R1.print("R1=");

	var x = QRGS.solve(Q1, R1, b);
	x.print("x=");
	var Ax = A1*x;
	Ax.print("Ax=");
	b.print("b=");
	
	WriteLine("Part b)");

	var B = QRGS.inverse(Q1,R1);
	var AB = A1*B;
	AB.print("AB=");




}	
}
