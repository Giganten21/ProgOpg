using System;
using static System.Math;
using static System.Console;
using System.Diagnostics;
class main{
static void Main(){
	int[] ns = new int [] {10,40,80,140,200,250,300,350,400};
	for(int p = 0; p<ns.Length; p++){
		Stopwatch hessenwatch = new Stopwatch();
		int n = ns[p];
		var rnd = new Random(1);
		var A = new matrix(n,n);
		for( int i=0;i<A.size1;i++)
			for( int j=i;j<A.size2;j++){
				A[i,j]=A[j,i]=rnd.NextDouble();
		}
		hessenwatch.Start();
		var (H,V) = jacobi.hessenberg(A);
		hessenwatch.Stop();
		double s = (double)ns[p];
		WriteLine($"{s}  {hessenwatch.Elapsed.TotalSeconds}");
	}
	WriteLine("\n");
	for(int k = 0; k<ns.Length; k++){
                Stopwatch qrwatch = new Stopwatch();
                int n = ns[k];
                var rnd = new Random(1);
                var A = new matrix(n,n);
                for( int l=0;l<A.size1;l++)
                        for( int m=l;m<A.size2;m++){
                                A[l,m]=A[m,l]=rnd.NextDouble();
                }
		qrwatch.Start();
		var (Q,R) = QRGS.decomp(A);
		qrwatch.Stop();
		double s = (double)ns[k];
		WriteLine($"{s}  {qrwatch.Elapsed.TotalSeconds}");

		
	}
}
}
