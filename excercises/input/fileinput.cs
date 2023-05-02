using System;
using System.IO;
using static System.Console;
using static System.Math;

class main{
	public static int Main(string[] args){

	string infile = null, outfile=null;
	foreach(string arg in args){
		var words = arg.Split(':');
		if(words[0]=="-input") infile = words[1];
		if(words[0]=="-output") outfile = words[1];
		}	
	if(infile!=null && outfile!=null){
		var inputstream = new StreamReader(infile);
		var outputstream = new StreamWriter(outfile,append:false);
		for(string line=inputstream.ReadLine();
				line != null;
				line=inputstream.ReadLine()){
		double x=double.Parse(line);
		outputstream.WriteLine($"{x: 0.00e+00;-0.00e+00}");
		}
		inputstream.Close();
		outputstream.Close();
	}

	return 0;
	}
}
