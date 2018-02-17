
import java.io.File;
import java.util.Random;

import weka.classifiers.Evaluation;
import weka.classifiers.trees.J48;
import weka.core.Instances;
import weka.core.converters.ArffSaver;
import weka.core.converters.CSVLoader;
import weka.core.converters.ConverterUtils.DataSource;
import weka.filters.Filter;
import weka.filters.unsupervised.attribute.Discretize;

public class Id3Dataset1 {
	public static void main(String args[]) throws Exception{
		// Converting the Training dataset  1  From CSV format to ARFF 
		//ARFF - Attribute Relation File Format
		CSVLoader loader = new CSVLoader();
		loader.setSource(new File("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Train1.csv"));
		Instances data = loader.getDataSet();
		
		ArffSaver saver = new ArffSaver();
		saver.setInstances(data);
		
		saver.setFile(new File("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Train1.arff"));
		saver.writeBatch();
		
		// Converting the Testing dataset 1  From CSV format to ARFF 
		//ARFF - Attribute Relation File Format
		CSVLoader loader1 = new CSVLoader();
		loader1.setSource(new File("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Test1.csv"));
		Instances data1 = loader1.getDataSet();
		
		ArffSaver saver1 = new ArffSaver();
		saver1.setInstances(data1);
		
		saver1.setFile(new File("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Test1.arff"));
		saver1.writeBatch();
		
		//Converting the numeric data to Nominal data 
		
		DataSource source = new DataSource("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Train1.arff");
		Instances dataset = source.getDataSet();		
		//set options
		String[] options = new String[4];
		//choose the number of intervals, e.g. 2 :
		options[0] = "-B"; options[1] = "2";
		//choose the range of attributes on which to apply the filter:
		options[2] = "-R";
		options[3] = "first-last";
		//Apply discretization:
		Discretize discretize = new Discretize();
		discretize.setOptions(options);
		discretize.setInputFormat(dataset);
		Instances newData = Filter.useFilter(dataset, discretize);

		
		ArffSaver saver2 = new ArffSaver();
		saver2.setInstances(newData);
		saver2.setFile(new File("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Train1Nominal.arff"));
		saver2.writeBatch();
		
		//Converting the numeric data to Nominal data 
		
		DataSource source1 = new DataSource("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Test1.arff");
		Instances dataset1 = source1.getDataSet();		
		//set options
		String[] options1 = new String[4];
		//choose the number of intervals, e.g. 2 :
		options1[0] = "-B"; options1[1] = "2";
		//choose the range of attributes on which to apply the filter:
		options1[2] = "-R";
		options1[3] = "first-last";
		//Apply discretization:
		Discretize discretize1 = new Discretize();
		discretize1.setOptions(options1);
		discretize1.setInputFormat(dataset1);
		Instances newData1 = Filter.useFilter(dataset1, discretize1);

		
		ArffSaver saver3 = new ArffSaver();
		saver3.setInstances(newData1);
		saver3.setFile(new File("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Test1Nominal.arff"));
		saver3.writeBatch();
		
		
		DataSource sourceTrain = new DataSource("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Train1Nominal.arff");
		Instances datasetTrain = sourceTrain.getDataSet();	
		//set class index to the last attribute
		datasetTrain.setClassIndex(datasetTrain.numAttributes()-1);
		//create and build the classifier!
		J48 tree = new J48();
		tree.buildClassifier(datasetTrain);
		System.out.println(tree.graph());
		Evaluation eval = new Evaluation(datasetTrain);
		Random rand = new Random(1);
		int folds = 10;
		
		//Notice we build the classifier with the training dataset
        //we initialize evaluation with the training dataset and then
        //evaluate using the test dataset

		//test dataset for evaluation
		DataSource sourceTest = new DataSource("C:\\Users\\Ankitha\\workspace\\DecisionTree\\Test1Nominal.arff");
		Instances testDataset = sourceTest.getDataSet();
		//set class index to the last attribute
		testDataset.setClassIndex(testDataset.numAttributes()-1);
		//now evaluate model
		eval.evaluateModel(tree, testDataset);
		//eval.crossValidateModel(tree, testDataset, folds, rand);
		System.out.println(eval.toSummaryString("Evaluation results:\n", false));
		
		System.out.println("Correct % = "+eval.pctCorrect());
		System.out.println("Incorrect % = "+eval.pctIncorrect());
		System.out.println("AUC = "+eval.areaUnderROC(1));
		System.out.println("kappa = "+eval.kappa());
		System.out.println("MAE = "+eval.meanAbsoluteError());
		System.out.println("RMSE = "+eval.rootMeanSquaredError());
		System.out.println("RAE = "+eval.relativeAbsoluteError());
		System.out.println("RRSE = "+eval.rootRelativeSquaredError());
		System.out.println("Precision = "+eval.precision(1));
		System.out.println("Recall = "+eval.recall(1));
		System.out.println("fMeasure = "+eval.fMeasure(1));
		System.out.println("Error Rate = "+eval.errorRate());
	    //the confusion matrix
		System.out.println(eval.toMatrixString("=== Overall Confusion Matrix ===\n"));
		
	}
}
