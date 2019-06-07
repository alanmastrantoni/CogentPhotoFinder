Firstly I checked in more frequently than I normally would to demonstrate progression. 
In a normal environment I would not check in to a shared repository code that does not compile or tests that would fail a build. 
I also usually perfer to build out the interface layer while building the tests. Just helps me validate my ideas.

Things considered: 

1. Command line parameters and switches could be added however I would do that via a third party nuget package which gives a nice way of adding switches.

2. I would also consider adding ILogging class to control where output is sent and that would be used in most classes. 
Would certainly be required in web api based systems with external input.

3. Repository based work added to consider other storage types and other file types. e.g database could have stored path and hash value on an upload feature.

4. I did consider also mocking out all the IO based method calls in there own mocks but given the repository and provider based piece did not seem necessary.
This also meant that there are a few integration tests to ensure that I used the write method calls and they returned what I expected. 
Have not done IO file based work in a while.

5. Solution should work over large file sets. Main concern left would be its performance. The area of concern would be the reading of the files now the code 
could be changed to get all files within the folders then using parall for each code you could load more than one file at a time. 
To be careful there RAM would be important on how many files could be loaded at a time and might even require a GC dispose. 
Ofc adding that kind of code I would make command switches with defaults to start it off.

6. As it is a console application I also did not worry about the life time scope of objects within DI. State would be a problem if running multiple operations.
DuplicateImageFinder.Core itself would be fine its onlt the console or host itself's concern.

7. The FileInfoWithHash could be extended to include other things like extension, name, or if other libraries were used potientially the caputured date time.

8. Alternative approaches although not full explored would be RGB type checking, width and size based checking, 
however at the end of the day each byte would need to be checked if I did not use a hashing technique that kind of approach would have slowed it down 
and I would have needed maybe to store first X bytes and last X bytes as a way potientially speeding it up. Also would have needed a hash table to store records in
and some sort of IComparable type implimentation.

Anyway thanks guys.

