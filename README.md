# FundesplayHackaton


A login esta creada una interfase en asp.net ( como se peude ver por los "<asp" la qual es una tabla con los label de texto las textbox para usuario y pasaporte y los botones 1 para conprobar si
los valores coinciden con los de la base de datos y la otra simplemente te redirige a register)
Hay que tener en cuenta que la contraseña que introduces pasa a estar cifrada junto con un codigo que se recibe del usuario ( con el nombre pobtienes la clase ) que luego se usa para cifrar la contrasenña
y comparas la contraseña cifrada con la contraseña de la base de datos que tambien esta cifrada

en el caso de register es otra interfase como login pero con solo un boto que inserta los datos escritos en la bas ede datos ( contraseña cifrada )
sin embargo antes de introducirlos comprueba si ya hay un usuario ya existente y en caso afirmativo no se introducen y te avisa que el usuario ya existe, si se completa el registro se te redirige al login 

el site.master es la barra superior que te permite moverte por la pagina permite deslogearte y reacciona segun el usuario logeado si se ha logeado para elllo se usan variables de session 
que tienen el nombre del usuario que se crean cuando se hace el login y se destruyen cuando se hace logout 

en default es una pagina que en caso de no estar logeado se te devuelve al login de forma automatica usando las variables de session ( an caso de no haber es que no se hizo login por lo que no se esta logeado)

en DBConnections en la carpeta DAL hay todas las operaciones que afectan a la base de datos realizar una conexion ( a una base de datos ya preparada), cerrar la conexion(simplemento es hacer un .closse de la variable conexion
, listar los usuarios ( se conecta y hace una query para extraes toda la informacion de la tabla de usuarios) que se utiliza tanto en el login como el registro para comparar la informacion introducida 
con la recibida y añadir los usuarios que se utiliza en el registro para crear nuevos usuarios ( es uana query con insert para la tabla usuariso de la base de datos)

el atributo usuario es creado en la carpeta Model siendo la unica clase existente en ella, se utiliza para gestionar los usuarios tanto en login como en register, al ser una clase con multiples atributos 
es una gran ayuda que esten "empaquetados"(cada atributo de usuario) en una clase que permite gestionar cada usuario como un solo atributo ( se puede obtener los atributos internos de usuario con usuario.atributo)
