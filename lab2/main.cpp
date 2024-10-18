#include <iostream>
#include <iomanip>
#define _USE_MATH_DEFINES
#include <math.h>

using namespace std;

const static int MAX = 10;
const static double A = 6, B = 12;
const static double H = 0.00001;

class Integral {
private:
	double func(double x) {
		return x * sqrt(x + 6);
	}

public:
	double calcLeft(double a, double b);
	double calcRight(double a, double b);
	double calcMiddle(double a, double b);
};
//========================================================================================
int main() {
	Integral f;
	cout << "Left: " << fixed << setprecision(4) << f.calcLeft(A, B) << endl;
	cout << "Right: " << fixed << setprecision(4) << f.calcRight(A, B) << endl;
	cout << "Middle: " << fixed << setprecision(4) << f.calcMiddle(A, B) << endl;

	return 0;
}
//========================================================================================
double Integral::calcLeft(double a, double b) {
	double h = (b - a) / MAX;
	double s = 0;
	double x = a;
	/*
	while (x < b) {
		s += h * func(x);
		x += h;
	}
	*/
	while (x < b) {
		s += H * func(x);
		x += H;
	}
	

	if (s < 0)
		return s * -1;
	return s;
}

double Integral::calcRight(double a, double b) {
	double h = (b - a) / MAX;
	double s = 0;
	double x = a;
	/*
	while (x < b) {
		s += h * func(x + h);
		x += h;
	}
	*/
	while (x < b) {
		s += H * func(x + H);
		x += H;
	}
	

	if (s < 0)
		return s * -1;
	return s;
}

double Integral::calcMiddle(double a, double b) {
	double h = (b - a) / MAX;
	double s = 0;
	double x = a;
	/*
	while (x < b) {
		double xAvg = (x + x + h) / 2;
		s += h * func(xAvg);
		x += h;
	}
	*/
	while (x < b) {
		double xAvg = (x + x + H) / 2;
		s += H * func(xAvg);
		x += H;
	}
	

	if (s < 0)
		return s * -1;
	return s;
}