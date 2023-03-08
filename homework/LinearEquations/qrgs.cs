using System;

public static class QRGS{
	public static void decomp(matrix Q, matrix R){
                var m = Q.size2;
                for(int i=0; i<m ;i++){
                        R[i,i] = Q[i].norm();
                        Q[i]/= R[i,i];
                        for(int j=i+1; j<m; j++){
                                R[i,j] = Q[i].dot(Q[j]);
                                Q[j] -= Q[i]*R[i,j];
                        }
                }
	
	}

	public static vector solve(matrix Q, matrix R, vector b){
		var c = Q.T * b;
		for(int i = c.size -1; i>=0; i--){
			double sum = 0;
			for(int k=i+1; k<c.size; k++)sum+=R[i,k]*c[k];
			
			c[i] = (c[i] - sum)/R[i,i];
		}
		return c;	
	}	

	public static double det(matrix R){
		int n = R.size2;
		double prod = 1;
		for(int i=0; i<n; i++){
			prod *= R[i,i];
		}
		return prod;
	}

	public static matrix inverse(matrix Q, matrix R){
		var m = Q.size2;
		var I = new matrix(m,m);
		I.set_identity();
		//A*xi = ei solve for xi
		//Q*R*A^-1 = I
		var B = new matrix(m,m);
		for (int i=0;i<m;i++){
			B[i] = solve(Q,R,I[i]);
		}

		return B;
	
	}

}	
