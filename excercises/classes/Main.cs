using System;
using static System.Console;
using static System.Math;

public static class main{

	public static void Main(){
		int n = 9;
		double[] a = new double[n];
		for(int i=0; i<n;i++) Write($"a[{i}] = {a[i]}1");
		WriteLine();
		for(int i=0;i<n;i++) a[i] = i;
		for(int i=0;i<n;i++) Write($"a[{i}] = {a[i]}");
		WriteLine();
		WriteLine($"array length = {a.Length}");
		foreach(double ai in a) Write($"ai = {ai}, ");
		WriteLine();

		vec v = new vec(5,2,3);
		v.print("v=");
		vec u = new vec(1,2,3);
		u.print("U=");
		Write("Making new objects\n");
		vec q = v*3;
		q.print("v*3=");

		vec x = q+u;
		x.print("q+u=");

		vec y = q-v;
		y.print("q-v=");
		
		double e = v%u;
		Write($"v.dot(u)={e}\n");

		vec f = new vec(5,6,7);
		vec g = new vec(4.99999999999,5.999999999,6.99999999);
		f.print();
		g.print();
		Write($"approx {f.approx(g)}\n");
	}

}
