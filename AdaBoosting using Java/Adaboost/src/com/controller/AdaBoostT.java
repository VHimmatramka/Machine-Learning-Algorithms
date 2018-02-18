package com.controller;
import java.awt.Color;
import java.io.BufferedReader;
import java.io.FileReader;
import java.io.IOException;

public class AdaBoostT {
	
	public SendData getErrors() throws IOException{
		FileReader fr = new FileReader("C:\\Users\\Bhavna\\Desktop\\e\\Adaboost\\T.txt"); 
		BufferedReader br = new BufferedReader(fr); 
		String s; 
		int inputs = 9;
		int patterns = 32;
		double values[][] = new double[patterns][inputs];	
		double error = 0;
		double accuracy [] = new double[values.length];
		String splited_values[];
		int counter = 0;
		SendData data = new SendData();
		data.errors = new double[patterns];
		while((s = br.readLine()) != null) { 
			splited_values = s.split(",");
			for(int i = 0 ; i < 9 ; i++){
				values[counter][i] = Double.parseDouble(splited_values[i]);
			}
			counter++;
		}
		double w[] = new double[inputs];
		double d[] = new double[patterns];
		
		System.out.println("Iteration No.    Error");
		
		for(int i = 0 ; i  < patterns ; i++){
			if(i < inputs/2){
				d[i] = 1;
			}
			else{
				d[i] = -1;
			}
		}
		for(int i = 0 ; i < inputs ; i++){
			w[i] = 1.0/inputs;
		}
		double lambda = 1;
		double eta = 1;
		for(int i = 0 ; i < values.length ; i++){
			double net = 0;
			for(int j = 0 ; j < values[i].length ; j++){
				net = net + w[j]*values[i][j];
			}
			System.out.println();
			double fnet = 2/(1 + Math.exp(-1 *lambda*net)) - 1;
//			if(fnet>0)
//				fnet=1;
//			else
//				fnet=-1;
			double dem = (1/2.0) * eta * (d[i] - fnet) * (1 - fnet*fnet);
			for(int j = 0 ; j < values[i].length ; j++){
				values[i][j] = dem * values[i][j];
			}
			for(int j = 0 ; j < w.length ; j++){
				w[j] = w[j] + values[i][j];
			}
			error =  0.5 * (d[i] - fnet)*(d[i] - fnet);	
			data.errors[i] = error;
			accuracy[i]=1-error;
			System.out.println(""+(i+1)+" \t\t "+error);
		}
		
		fr.close();
		double sum=0.0;
		for(int i=0; i<accuracy.length; i++)
			sum=sum+accuracy[i];
		System.out.println();
		data.accuracy = (sum/accuracy.length)*100;
		System.out.println("Overall Accuracy: "+(sum/accuracy.length)*100+"%");
		return data;
	}
}