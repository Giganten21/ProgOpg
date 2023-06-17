using System;
using static System.Console;
using static System.Math;
using System.Collections.Generic;
class main{

static Func<double,vector,vector>
	F=delegate(double x, vector y){
	return new vector(y[1],-y[0]);  /*sin(x)' = -cos(x) */
		};

static void Main(){
	vector ya = new vector(0,1);
	double a = 0;	
	double b = 2*PI;
	double h=0.01,acc=1e-2,eps=1e-2;
	(genlist<double> xs, genlist<vector> ys) = ode.driver(F,a,ya,b,acc:acc,eps:eps,h:h);
	for(int i=0;i<xs.size;i++)
		WriteLine($"{xs[i]} {ys[i][0]} {ys[i][1]}");

		}
}
