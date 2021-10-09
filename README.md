# business-register

Group project of two classmate!

The program  allows the user to add companies, delete companies, see a list of all companies and search/sort companies. In the register, the user will enter the company name and company address and then choose between 7 different sectors in which the company can work. User will be able to see all the companies that are already registered in the register. There will be two different choices to search within the vector. The first choice will be a sort based on the sector as one
companies find themselves within. You will be able to search for a certain sector and get as output number of companies registered in that sector. The second method will be to sort all the companies in the vector based on the alphabetical order of their names. In this case, we have implemented that
the method will sort the companies from A-Z. The user will also be able to delete a company that has been registered.


The program is divided into Main and Corporate class. The corporate class contains the variables that needed to create a business. These variables are;
- String name
- String address
- String sector

It also contains the rest of the methods used in the program in main. The program uses
out of a one loop to print the menu which then has the following options RegisterCompany ();,
DownloadAllCompanies ();, DeleteCompanies (); and MenuTry ();. When the user enters one of the
following choices, the program will then call that method and then run what is within
the code. Then there is also the method AddToArr (Company length), which adds new companies
the vector.


We also want the program to be able to save the companies that you register, so that when you
ends the program and then starts it again, then the companies that you registered earlier come
still in the register. We use StreamReader and StreamWriter as they write
the companies that we have registered for a text file called Företag.txt and later it will come
StreamReader to read out the companies from Company.txt when they come to the use of the method
DownloadAllCompanies(), because this method retrieves its list of companies from CompanyArr.Length
which contains the companies that saved the help of StreamWriter.
When we want to delete a company, the user will see the list of all the companies that are already
registered by the GetAllCompany() method;. It will find out if they name it
the company specified by the user is in FöretasArr.length and delete it if you find it in the Vector.
We want to use several different sorting methods such as when we want to SortArrayBy Letter()
or SearchAfterSector() when we sort / search through the vector based on what we want to find. We used
a bubblesort when we want to SortArrayAfterLetters() and when we use the method
Search for Sector(). We will find the number of companies within a certain "class" by going through the whole vector
and searches for the names.sector that matches with the names.sector entered by the user
