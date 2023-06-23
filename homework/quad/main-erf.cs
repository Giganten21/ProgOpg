using System;
using static System.Console;
using static System.Math;

class main{
static void Main(){
	int n = 4;
	//var x = new double[n];
	//var y = new double[n];
	string k = "0.02,0.1,0.4,0.9";
	string l = "0.02256,0.112462916,0.428392355,0.796908212";
	string[] karray = k.Split(",");
	string[] larray = l.Split(",");
	for(int i=0; i<n;i++){
		WriteLine($"{karray[i]} {larray[i]}");
	}
	WriteLine("\n");
	//double step = 0.01;
	for(double j = -3; j<3; j+=1.0*0.32){
		WriteLine($"{j} {er.erf(j)}");
	}
	WriteLine("\n\n");
	for(double j = -3; j<3; j+=1.0*0.01){
		WriteLine($"{j} {sfuns.erf(j)}");
	}
}
}
