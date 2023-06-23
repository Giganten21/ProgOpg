using System;
using static System.Console;
using static System.Math;


public static class main{
	public static void Main(){
		WriteLine("#######test######");
		Func<vector,vector> f = x => new vector (x[0]*x[0]+4*x[0]-3);
		WriteLine("Function is x**2 + 4x - 3");
		vector s0 = new vector(1); //start value vector
		s0[0] = 2; 		   //start value
		vector s00 = new vector(1);
		s00[0] = -5;
		var root1 = roots.newton(f,s0);
		var root11 = roots.newton(f,s00);
		root1.print("Root 1 = ");
		root11.print("Root 2 = ");
		f(root1).print("f(root 1) should be 0: ");
		f(root11).print("f(root 2) should be 0: ");
		WriteLine("\n");

		Func<vector,vector> f1 = x => new vector (2*x[0]*x[1], -x[1]*x[1]+3);
		WriteLine("Function is f(x,y) = (2*x*y, -y^2+3)");
		vector s1 = new vector(1.0,1.0);
		var root2 = roots.newton(f1,s1);
		root2.print("Roots = ");
		f1(root2).print("f(root) should be 0: ");
		
		WriteLine("\n");
		//f(x,y) = (1-x)**2+100(y-x2)**2
		//f'(x,y) = -2*(1-x)+400*x(y-x**2) , 200*(y-x**2)
		WriteLine("######Rosenbrock's valley#####");
		WriteLine("Function is: f(x,y)=(1-x)^2+100(y-x^2)^2");
		Func<vector,vector> R = x => new vector (-2*(1-x[0])+400*x[0]*(x[1]-x[0]*x[0]), 200*(x[1]-x[0]*x[0]));
		WriteLine("Analytical gradiant");
		WriteLine("f'(x,y) = -2*(1-x)+400*x(y-x**2) , 200*(y-x**2)");
		vector r = new vector(1.0,3.0);
		var root = roots.newton(R,r);
		root.print("Roots = ");
		R(root).print("f(roots) = ");
	}
}
