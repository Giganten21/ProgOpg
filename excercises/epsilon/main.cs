using System;
using static System.Console;
using static System.Math;

public static class main{
	public static void Main(){
	int i=1; while(i+1>i) {i++;}
	Write("my max int = {0}\n",i);
	Write($"True max int = {int.MaxValue}\n");
	int j=1; while(j-1<j) {j--;}
	Write("my min int = {0}\n",j);
	Write($"True min int = {int.MinValue}\n");

	double x=1; while(1+x!=1){x/=2;} x*=2;
	float y=1F; while((float)(1F+y) != 1F){y/=2F;} y*=2F;
	Write($"Float={x}, Double={y} and 2**-52 = {Pow(2,-52)}\n");

	int n=(int)1e6;
	double epsilon=Pow(2,-52);
	double tiny=epsilon/2;
	double sumA=0,sumB=0;

	sumA+=1; for(int k=0;k<n;k++){sumA+=tiny;}
	for(int k=0;k<n;k++){sumB+=tiny;} sumB+=1;

	WriteLine($"sumA-1 = {sumA-1:e} should be {n*tiny:e}");
	WriteLine($"sumB-1 = {sumB-1:e} should be {n*tiny:e}");
	WriteLine("As sumA starts as an int, it does not add the same. When adding floats.");

	double d1 = 0.1+0.1+0.1+0.1+0.1+0.1+0.1+0.1;
	double d2 = 8*0.1;
	WriteLine($"d1={d1:e15}");
	WriteLine($"d2={d2:e15}");
	WriteLine($"d1==d2 ? => {d1==d2}");

	WriteLine($"With approx, d1=d2 {sfuns.approx(d1,d2)}");
}
}
