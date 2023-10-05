<h1>BlazorServerAp</h1>

<h2>Framework</h2>

<h3>Blazor Server-Side</h3>

<p>
Blazor permite crear aplicaciones web utilizando .NET. Existen dos enfoques principales: Server-Side y Client-Side. En esta aplicación, hemos elegido trabajar con Blazor Server-Side. 
</p>
<p>
Una de las principales ventajas de Blazor Server-Side es que permite manejar una base de datos directamente desde el backend del código, permitiendo operaciones más integradas y fluidas. Por otro lado, Blazor Client-Side, también conocido como WebAssembly, se ejecuta de manera más rápida, pero no posee la misma facilidad para manejar bases de datos directamente. En lugar de eso, realiza llamadas a APIs para obtener o manipular datos.
</p>
<p>
Blazor como framework es revolucionario ya que permite que el navegador interprete C# directamente. Es un framework orientado a componentes, lo que implica que se debe apuntar a que los componentes sean reutilizables y modulares.
</p>

<h2>Descripción de la aplicación</h2>

<p>
La aplicación es una red social destinada a eventos, celebraciones y días internacionales en países hispanohablantes. Los usuarios tendrán acceso a un calendario general y podrán visualizar y compartir DIY (Hazlo Tú Mismo) para festividades, utilizando materiales comunes y accesibles.
</p>

<h3>Características principales:</h3>

<ol>
    <li><strong>Calendario General</strong>: Donde se muestran los días festivos y celebraciones de los países hispanohablantes.</li>
    <li><strong>Publicaciones DIY</strong>: Los usuarios pueden subir y compartir sus propias creaciones con instrucciones, links a videos, insumos utilizados, costos, tiempo de realización, entre otros detalles.</li>
    <li><strong>Filtro Personalizado</strong>: Los usuarios pueden filtrar las publicaciones según sus necesidades y preferencias.</li>
    <li><strong>Búsqueda por Material</strong>: Si un usuario tiene ciertos materiales a mano, puede buscar proyectos que los utilicen.</li>
    <li><strong>Calendario Personal</strong>: Dependiendo del avance del proyecto, cada usuario podrá tener un calendario propio para fechas personales importantes.</li>
</ol>

<h2>Tecnologías y herramientas</h2>

<h3>Firebase</h3>

<p>
La aplicación se integra con Firebase para manejar autenticación de usuarios, almacenamiento de imágenes y como base de datos para las publicaciones. Firebase proporciona soluciones escalables y en tiempo real para nuestras necesidades.
</p>

<h3>Modelo-Vista-Controlador (MVC)</h3>

<p>
Para mantener el código organizado y facilitar su mantenimiento, se ha decidido utilizar el patrón arquitectónico Modelo-Vista-Controlador (MVC). Esto nos permite separar la lógica de negocio, la interfaz de usuario y el acceso a los datos.
</p>

<h2>¿Cómo comenzar?</h2>

<ol>
    <li><strong>Instalación</strong>:
        <ul>
            <li>Asegúrese de tener instalado .NET Core SDK.</li>
            <li>Clone este repositorio.</li>
            <li>Ejecute <code>dotnet restore</code> para instalar las dependencias.</li>
        </ul>
    </li>
    <li><strong>Configuración de Firebase</strong>:
        <ul>
            <li>Visite la consola de Firebase y cree un nuevo proyecto.</li>
            <li>Configure las reglas de autenticación y base de datos según sus necesidades.</li>
            <li>Integre las credenciales en la aplicación.</li>
        </ul>
    </li>
    <li><strong>Ejecución</strong>:
        <ul>
            <li>Desde el directorio raíz, ejecute <code>dotnet run</code>.</li>
        </ul>
    </li>
</ol>
