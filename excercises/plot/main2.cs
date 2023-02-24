using System;
using static System.Math;
using static System.Console;
class main{
static void Main(){
	for(double x=0+1.0/128;x<=3;x+=1.0/64){
		WriteLine($"{x} {sfuns.erf(x)}");
	}
}
}
