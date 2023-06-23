using System;
using static System.Console;
using static System.Math;

public class main{
public static vector GenerateTrainingData(double start, double end, double step){
	int size = (int)Math.Ceiling((end - start) / step) + 1;
	vector data = new vector(size);
	double x = start;
	for (int i = 0; i < size; i++){
		data[i] = x;
		x += step;
	}
	return data;
}

public static void Main(){
	//Target Function
	Func<double,double> target = x => Cos(5 * x - 1) * Exp(-x * x);

	double start = -1;
	double stop = 1;
	double trainingStep = 0.1;
	double evalStep = 0.001;
	//Generating training data
	vector xTrain = GenerateTrainingData(start, stop, trainingStep);
	vector yTrain = xTrain.map(target);
	
	for(int i = 0; i<xTrain.size;i++){
		WriteLine($"{xTrain[i]} {yTrain[i]}");
		}
	WriteLine("\n");
	//Network
	ann network = new ann(10,target);

	network.train(xTrain,yTrain);

	vector xtest = GenerateTrainingData(start, stop, evalStep);
	vector ytest = xtest.map(target);

	for(int i = 0;i<xtest.size; i++){
		double x = xtest[i];
		double ypred = network.response(x);
		double y = ytest[i];
		WriteLine($"{x} {ypred}");
	}
	

}
}
