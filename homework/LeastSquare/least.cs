using System;
using static System.Math;

static(vector,matrix) lsfit (
	Func<double,double>[]fs,vectorx,vectory,vectordy){ 
	int n = x.size, m = fs.Length;
	var A = new matrix(n,m);
	var b = new vector(n);
	for(inti=0;i<n;i++){ 
		b[i]=y[i]/dy[i]; 
		for(intk=0;k<m;k++)A[i,k]=fs[k](x[i])/dy[i];
		} 
	var qra = new GSQR(A); 
	vector c = qra.solve(b); 
	var pinvA = qra.pinverse(); 
	var S = pinvA∗pinvA.T;
	return(c,S);
}
