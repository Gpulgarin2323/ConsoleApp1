# ConsoleApp1
Test para Belatrix
1.	Separaría la clase que contienen todo el código en 2 clases más que van a manejar el guardado de los Logs. Además, de separar las clases utilizaría un condicional de control para el guardado de los logs ya se en archivo de texto o en la base de datos mostrando en consola, esto con el fin de simplificar el código. También agruparía los tipos de mensajes en una sola variable de tipo int llamada TypeofMessage que recibe los enteros  “1” es mensaje, “2” es advertencia y “3” es error, dado que al manejar 3 por separado ( message, error, warning) generan más código y puede aumentar la complejidad a la hora de entender el código, utilizaría de igual forma una variable de tipo int para manejar la opción de guardado ya sea “1” para texto, “2” para base de datos y consola. Crearía un solo método que reciba las variables específicas como (message, TypeOfMessage y OptionOfSave)  siendo este el  método principal que haría el llamado a el método auxiliar  que contiene la lógica para guardar los logs teniendo en cuenta los parámetros que se le hallan suministrado dejando de esta forma todo el código anterior en una biblioteca de clases .NET STANDARD con 2 clases SaveLog que es el método principal y HelperSaveLogger que es el método auxiliar encargado de procesar los parámetros recibidos y cumplir con la funciones ya antes mencionadas.
2.	It would separate the class containing all the code into 2 more classes that are going to handle the saving of the Logs. Besides, to separate the classes would use a control conditional for the saving of the logs already in text file or in the database showing in console, this in order to simplify the code. It would also group the types of messages in a single int type variable called TypeofMessage that receives the integers "1" is message, "2" is warning and "3" is error, since handling 3 separately (message, error, warning) generates more code and can increase the complexity when understanding the code, would use in the same way an int type variable to handle the option of saving either "1" for text, "2" for database and console. It would create a single method that receives specific variables such as (message, TypeOfMessage and OptionOfSave) being this the main method that would make the call to the auxiliary method that contains the logic to save the logs taking into account the parameters that are supplied leaving this way all the previous code in a library of classes .NET STANDARD with 2 classes SaveLog that is the main method and HelperSaveLogger that is the auxiliary method in charge of processing the received parameters and fulfilling the functions already mentioned.
