package com.controller;

import java.io.IOException;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
public class Controller extends HttpServlet {
	private static final long serialVersionUID = 3L;
    public Controller(){
    	
    }
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String action = request.getParameter("action");
		
		if(action == null){
			request.getRequestDispatcher("index.jsp").forward(request, response);
		}
		
		else{
			doPost(request, response);
		}
	}
	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		String action = request.getParameter("action");
		if(action.equals("adaboost")){
			AdaBoostT adaboost = new AdaBoostT();
			SendData data = adaboost.getErrors();
			HttpSession session = request.getSession(true);
			session.setAttribute("data", data);
			request.getRequestDispatcher("output.jsp").forward(request, response);
		}
		if(action.equals("fv")){
			FeatureVector adaboost = new FeatureVector();
			SendData data = adaboost.featureVector();
			HttpSession session = request.getSession(true);
			session.setAttribute("data", data);
			request.getRequestDispatcher("feature.jsp").forward(request, response);
		}
		if(action.equals("x")){
			DatasetX adaboost = new DatasetX();
			SendData data = adaboost.datasetX();
			HttpSession session = request.getSession(true);
			session.setAttribute("data", data);
			request.getRequestDispatcher("datasetx.jsp").forward(request, response);
		}
	}

}
