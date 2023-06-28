My student number ends in 73 so i had to do excersise 21.
This excersise implements the hessenberg factorization using Jacobi transformation. J(2,3),J(2,4),...,J(2,n),J(3,4),...,J(3,n),...,J(n-1,n) applying this sequence of jacobi tranformation will reduce an (nxn) matrix to its hessenberg form, as is zeros out all the elements above the first sub diagonal.

I did all of the excerise plus the extra where the time compared to the QR decompsistion is ploted in Compare.svg, and computed the determinant. All the relavent output is in Out.txt and the svg file. As I did all the excerise i think the performance is between a 9 or 10.

While figuring out how to make the hessenberg method, I first tried to impliment it as is described in the excersises, but didn't know to how compute theta. First I tried the one form Jacobi cyclic tranformation, but that didn't work. After trying a bunch of different ways I emailed Dimitri and got the hit to look at eq. 4.10. From here I got a theta the worked. I also checked the identities A = Q*H*Q.t and I = Q*Q.T and these are correct.

Testing the time for the two diagonalization QR proved to be the faster by a factor of about two, depending on the matrix as the curve is not smooth.

The determinant was easy to calculate, using the QR decompsistion from previous homework and multiplying all the diagonal elements gave the determinant.