using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
class main{

public static double fun_to_fit(double t){return Math.Log(t);}

public static double Fc(Func<double,double>[] fs,vector c,double x){
   double s=0;
   for(int i=0;i<fs.Length;i++) s+=c[i]*fs[i](x);
   return s;
}

public static void Main(){
	int n = 9;
	var x = new double[n];
	var y = new double[n];
	var dy = new double[n];
	var lny = new double[n];
	var dlny = new double[n];
	string k = "1,2,3,4,6,9,10,13,15";
	string l = "117,100,88,72,53,29.5,25.2,15.2,11.1";
	string m = "5,5,5,4,4,3,3,2,2";
	string[] karray = k.Split(",");
	string[] larray = l.Split(",");
	string[] marray = m.Split(",");

	for(int i=0;i<n;i++){
		x[i] = Convert.ToDouble(karray[i]);
		y[i] = Convert.ToDouble(larray[i]);
		dy[i] = Convert.ToDouble(marray[i]);
		dlny[i] = dy[i]/y[i];
		lny[i] = fun_to_fit(y[i]);
		WriteLine($"{x[i]} {lny[i]} {dlny[i]}");
		}
	Write("\n\n");
	var fs = new Func<double,double>[] { z => 1.0, z => z, z => z*z };
	(vector c, matrix S) = lsfit.fit(fs,x,lny,dlny);
	var dc = new vector(fs.Length);
	for(int i=0;i<fs.Length;i++)dc[i]=Sqrt(S[i,i]);
	for(double z=x[0];z<=x[8];z++) WriteLine($"{z} {Fc(fs,c,z)}");
	Write("\n\n");
	for(double z=x[0];z<=x[8];z++) WriteLine($"{z} {Fc(fs,c+dc,z)}");
	Write("\n\n");
	for(double z=x[0];z<=x[8];z++) WriteLine($"{z} {Fc(fs,c-dc,z)}");
	Write("\n\n");

	double lambda = (lny[8] - lny[0]) / (x[8] - x[0]);
	double dlambda = (Math.Log(2) / Math.Pow(lambda,2))*dlny[8];
	WriteLine($"T_1/2 = {-Math.Log(2)/lambda} days real is 3.631 days. Uncertainty {dlambda} days");
	}//Main
}//main
