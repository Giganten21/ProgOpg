using System;
using static System.Math;
public static partial class lsfit{
public static (vector,matrix) fit(
	Func<double,double>[] fs, vector x, vector y, vector dy){ 
	int n = x.size, m = fs.Length;
	var A = new matrix(n,m);
	var b = new vector(n);
	for(int i=0;i<n;i++){ 
		b[i]=y[i]/dy[i]; 
		for(int k=0;k<m;k++)A[i,k]=fs[k](x[i])/dy[i];
		} 
	var qra = new GSQR(A); 
	vector c = qra.solve(b); 
	var pinvA = qra.pinverse(); 
	var S = pinvA*pinvA.T;
	return(c,S);
}
}
