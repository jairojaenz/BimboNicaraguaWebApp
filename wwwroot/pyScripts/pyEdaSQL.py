import edaSQL  # Importa la biblioteca edaSQL para el análisis exploratorio de datos
import pandas as pd  # Importa pandas para el manejo de datos
import pyodbc  # Importa pyodbc para la conexión con la base de datos SQL Server
import matplotlib.pyplot as plt  # Importa Matplotlib para la visualización de datos
import mpld3  # Importa mpld3 para generar gráficos dinámicos en HTML
import sys  # Importa sys para acceder a los argumentos del script
import io 
import seaborn as sns  # Importa seaborn para mejorar la visualización de los gráficos
import base64  # Importa base64 para codificar la imagen

# Verifica si se proporciona la ruta del archivo de salida
if len(sys.argv) > 1:
    output_file_path = sys.argv[1]  # Leer la ruta del archivo de salida desde los argumentos del script
else:
    # Si no se proporciona, usa un valor predeterminado o termina la ejecución con un mensaje de error
    print("Error: No se proporcionó la ruta del archivo de salida.")
    sys.exit(1)

# Configuración de la conexión a la base de datos
server = 'relacionalbimbo.database.windows.net'
database2 = 'DimensionesPanPlus'
username = 'relbimbo'
password = 'BDS22024Grupo#2'
driver = '{ODBC Driver 17 for SQL Server}'

# Intenta establecer la conexión utilizando autenticación de Windows
try:
    conn = pyodbc.connect(
        f'DRIVER={driver};'
		f'SERVER={server};'
		f'DATABASE={database2};'
		f'UID={username};'
		f'PWD={password};'
		f'PORT=1433;'
	)
except Exception as e:
    with open(output_file_path, 'w', encoding='utf-8') as file:
        file.write(f"Error al conectar a la base de datos: {e}")
    sys.exit(1)

# Primera consulta SQL para extraer los datos completos de la base de datos
query1 = """
SELECT HechosVentas.[Date Key], Dim_Date.Date, Dimension_Productos.[Nombre Producto], Dimension_Productos.[Descripcion Producto], Dimension_Productos.[Precio Producto], Dimension_Productos.[Categoria Producto], Dimension_Productos.[Nombre Proveedor], Dimension_Productos.[Contacto Proveedor], Dimension_Productos.[Ubicacion Proveedor], 
         HechosVentas.[Cantidad Venta], HechosVentas.[Precio Unitario], Dimension_Cliente.[Nombre Cliente], Dimension_Cliente.[Tipo Cliente], Dimension_Cliente.[Contacto Cliente], Dimension_Cliente.[Ubicacion Cliente], Dimension_Cliente.[Departamento Cliente], Dimension_Cliente.[Municipio Cliente]
FROM  Dim_Date INNER JOIN
         HechosVentas ON Dim_Date.[Date Key] = HechosVentas.[Date Key] INNER JOIN
         Dimension_Cliente ON HechosVentas.[Cliente Key] = Dimension_Cliente.[Cliente Key] INNER JOIN
         Dimension_Productos ON HechosVentas.[Producto Key] = Dimension_Productos.[Producto Key]
"""

# Segunda consulta SQL para extraer datos específicos para el gráfico de correlación
query2 = """
SELECT HV.[Cantidad Venta],
       HV.[Precio Unitario],
       (HV.[Cantidad Venta] * HV.[Precio Unitario]) as [Total Venta]
FROM HechosVentas as HV
"""

# Lee los datos en DataFrames de pandas desde la base de datos
data1 = pd.read_sql(query1, conn)
data2 = pd.read_sql(query2, conn)

# Abre el archivo de salida para escribir el contenido en formato HTML
with open(output_file_path, 'w', encoding='utf-8') as file:
    # Muestra las primeras filas del DataFrame de la primera consulta en formato HTML
    file.write("<h2>Datos Completos - Primeras 10 filas</h2>")
    file.write(data1.head(10).to_html(index=False, classes='table table-striped table-responsive'))

    # Resumen estadístico de las columnas numéricas de la primera consulta
    file.write(data1.describe().to_html(index=False, classes='table table-striped table-bordered'))

    # Usa edaSQL para generar un análisis exploratorio de datos (EDA) para la primera consulta
    eda_report1 = edaSQL.EDA(dataFrame=data1).dataInsights()

    # Formatea el informe EDA en formato HTML para la primera consulta
    file.write("<h2>Informe EDA con edaSQL - Datos Completos</h2>")
    html_report1 = "<table border='1' class='table table-striped table-bordered'>"
    for key, value in eda_report1.items():
        if isinstance(value, dict):
            html_report1 += f"<tr><th colspan='2'>{key}</th></tr>"
            for k, v in value.items():
                html_report1 += f"<tr><td>{k}</td><td>{v}</td></tr>"
        else:
            html_report1 += f"<tr><td>{key}</td><td>{value}</td></tr>"
    html_report1 += "</table>"
    file.write(html_report1)

    # Muestra las primeras filas del DataFrame de la segunda consulta en formato HTML
    file.write("<h2>Datos para el Gráfico - Primeras 10 filas</h2>")
    file.write(data2.head(10).to_html(index=False, classes='table table-striped table-bordered'))

    # Resumen estadístico de las columnas numéricas de la segunda consulta
    file.write(data2.describe().to_html(index=False, classes='table table-striped table-bordered'))

    # Usa edaSQL para generar un análisis exploratorio de datos (EDA) para la segunda consulta
    eda_report2 = edaSQL.EDA(dataFrame=data2).dataInsights()

    # Formatea el informe EDA en formato HTML para la segunda consulta
    file.write("<h2>Informe EDA con edaSQL - Datos para el Gráfico</h2>")
    html_report2 = "<table border='1' class='table table-striped table-bordered'>"
    for key, value in eda_report2.items():
        if isinstance(value, dict):
            html_report2 += f"<tr><th colspan='2'>{key}</th></tr>"
            for k, v in value.items():
                html_report2 += f"<tr><td>{k}</td><td>{v}</td></tr>"
        else:
            html_report2 += f"<tr><td>{key}</td><td>{value}</td></tr>"
    html_report2 += "</table>"
    file.write(html_report2)

    # Realiza un análisis de correlación de Pearson utilizando solo las columnas numéricas seleccionadas de la segunda consulta
    numerical_data = data2[['Cantidad Venta', 'Precio Unitario', 'Total Venta']]
    corr = numerical_data.corr()

    plt.figure(figsize=(10, 8))
    sns.heatmap(corr, annot=True, cmap='coolwarm', fmt=".2f", linewidths=.5)
    plt.title('Correlación de Pearson')

    # Guardar el gráfico en un objeto de bytes
    buf = io.BytesIO()
    plt.savefig(buf, format='png')
    buf.seek(0)

    # Convertir el gráfico de Matplotlib a base64
    img_base64 = base64.b64encode(buf.read()).decode('utf-8')
    buf.close()

    # Crear HTML para la imagen
    file.write("<h2>Gráfico de Correlación de Pearson</h2>")
    file.write(f'<img src="data:image/png;base64,{img_base64}" alt="Gráfico de Correlación de Pearson">')

    # Genera el gráfico interactivo con mpld3
    html_fig = mpld3.fig_to_html(plt.gcf())
    
    # Incrusta el gráfico en el HTML
    file.write("<h2>Gráfico de Correlación de Pearson</h2>")
    file.write(html_fig)

    # Genera un joinplot con puntos de diferentes colores para cada variable
    sns.set(style="whitegrid")
    g = sns.FacetGrid(data2.melt(), col="variable", hue="variable", palette="tab10", col_wrap=3, height=4, aspect=1)
    g.map(sns.scatterplot, "value", "value", alpha=0.7)
    g.add_legend()

    # Guardar el gráfico en un objeto de bytes
    buf = io.BytesIO()
    plt.savefig(buf, format='png')
    buf.seek(0)

    # Convertir el gráfico de Matplotlib a base64
    img_base64 = base64.b64encode(buf.read()).decode('utf-8')
    buf.close()

    # Crear HTML para la imagen
    file.write("<h2>Gráfico Joinplot</h2>")
    file.write(f'<img src="data:image/png;base64,{img_base64}" alt="Gráfico Joinplot">')

    # Genera el gráfico interactivo con mpld3
    html_fig = mpld3.fig_to_html(plt.gcf())

    # Incrusta el gráfico en el HTML
    file.write("<h2>Gráfico Joinplot</h2>")
    file.write(html_fig)

    # Genera un boxplot
    plt.figure(figsize=(10, 8))
    sns.boxplot(data=data2)
    plt.title('Boxplot de Datos')
    plt.xlabel('Variables')
    plt.ylabel('Valores')

    # Guardar el gráfico en un objeto de bytes
    buf = io.BytesIO()
    plt.savefig(buf, format='png')
    buf.seek(0)

    # Convertir el gráfico de Matplotlib a base64
    img_base64 = base64.b64encode(buf.read()).decode('utf-8')
    buf.close()

    # Crear HTML para la imagen
    file.write("<h2>Boxplot de Datos</h2>")
    file.write(f'<img src="data:image/png;base64,{img_base64}" alt="Boxplot de Datos">')

    # Genera el gráfico interactivo con mpld3
    html_fig = mpld3.fig_to_html(plt.gcf())

    # Incrusta el gráfico en el HTML
    file.write("<h2>Boxplot de Datos</h2>")
    file.write(html_fig)

    # Genera un barplot
    plt.figure(figsize=(10, 8))
    sns.barplot(x=data2.columns, y=data2.mean(), palette="viridis")
    plt.title('Barplot de Promedios')
    plt.xlabel('Variables')
    plt.ylabel('Promedios')

    # Guardar el gráfico en un objeto de bytes
    buf = io.BytesIO()
    plt.savefig(buf, format='png')
    buf.seek(0)

    # Convertir el gráfico de Matplotlib a base64
    img_base64 = base64.b64encode(buf.read()).decode('utf-8')
    buf.close()

    # Crear HTML para la imagen
    file.write("<h2>Barplot de Promedios</h2>")
    file.write(f'<img src="data:image/png;base64,{img_base64}" alt="Barplot de Promedios">')

    # Genera el gráfico interactivo con mpld3
    html_fig = mpld3.fig_to_html(plt.gcf())

    # Incrusta el gráfico en el HTML
    file.write("<h2>Barplot de Promedios</h2>")
    file.write(html_fig)