using System;
using static System.Math;
using static System.Console;

class main{
	
	static void Main(string[] args){
		var rand = new Random();
		int n=rand.Next(3,7);
/*		foreach(string arg in args){
			var words = arg.Split(':');
			if(words[0]=="-size")n=(int)double.Parse(words[1]);
			}
*/		var A = new matrix(n,n);
		var rnd = new Random(1);
		for( int i=0;i<A.size1;i++)
			for( int j=i;j<A.size2;j++){
				A[i,j]=A[j,i]=rnd.NextDouble();
			}
		WriteLine("Laver A og kører jacobi som bliver til D og laver V."); 
		A.print("A=");
		var D = A.copy();
		matrix V = jacobi.cyclic(D);
		D.print("D=");
		V.print("V=");

		var x = V.T*A*V;
		x.print("V.T*A*V=");
		WriteLine("Dette er D");

		var y = V*D*V.T;
		y.print("V*D*V.T=");
		WriteLine("Detter er A");
		var z1 = V*V.T;
		var z2 = V.T*V;
		WriteLine("Tjekker at disse er = I");
		z1.print("V*V.T=");
		z2.print("V.t*V=");


		



	}
}
