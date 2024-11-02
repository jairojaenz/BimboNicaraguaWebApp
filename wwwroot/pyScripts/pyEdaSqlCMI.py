import edaSQL
import pandas as pd
import pyodbc
import sys
import matplotlib.pyplot as plt
import mpld3
import io
import seaborn as sns
import base64

# Verifica si se proporciona la ruta del archivo de salida
if len(sys.argv) > 1:
    output_file_path = sys.argv[1]  # Leer la ruta del archivo de salida desde los argumentos del script
else:
    print("Debe proporcionar la ruta del archivo de salida como argumento del script.")
    sys.exit(1)
server = 'relacionalbimbo.database.windows.net'
database = 'CMI_Bimbo'
username = 'relbimbo'
password = 'BDS22024Grupo#2'
driver = '{ODBC Driver 17 for SQL Server}'
try:
	conn = pyodbc.connect(
		f'DRIVER={driver};'
		f'SERVER={server};'
		f'DATABASE={database};'
		f'UID={username};'
		f'PWD={password};'
        f'PORT=1433;'
	)
    
except Exception as e:
    with open(output_file_path, 'w', encoding='utf-8') as file:
        file.write(f"Error al conectar a la base de datos: {e}")
    sys.exit(1)

# Query SQL para extraer los datos de la base de datos
query = """
exec datosCmi
"""

# Lee los datos en un DataFrame de pandas desde la base de datos
data = pd.read_sql(query, conn)

#server2='localhost'
#database2='DimencionesPanPlus'
#driver2='ODBC Driver 17 for SQL Server'
server = 'relacionalbimbo.database.windows.net'
database2 = 'DimensionesPanPlus'
username = 'relbimbo'
password = 'BDS22024Grupo#2'
driver = '{ODBC Driver 17 for SQL Server}'

try:
    conn2 = pyodbc.connect(
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

query2 = """
exec datosDimenciones
"""

data2 = pd.read_sql(query2, conn2)

# Abre el archivo de salida para escribir el contenido en formato HTML
with open(output_file_path, 'w', encoding='utf-8') as file:
    # Muestra todas las filas del DataFrame en formato HTML
    file.write(data.to_html(classes='table table-striped table-bordered table-responsive'))
    file.write(data2.to_html(classes='table table-striped table-bordered'))
    #Convertir la columnna Mes a tipo fecha
    data2['Mes'] = pd.to_datetime(data2['Mes'])

    # Crear un grafico histograma de las columnas x= Mes y= Tasa de Retencion
    plt.figure()
    #cambiar tamanio del grafico
    plt.figure(figsize=(10, 5))
    sns.barplot(data=data2, x=data2['Mes'].dt.strftime('%B'), y='Tasa de Retencion')
    plt.title('Tasa de Retencion de clientes por Mes (%)')
    plt.xlabel('Mes')
    plt.ylabel('Tasa de Retencion')
    plt.xticks(rotation=25)
    # Guardar la imagen en un buffer
    buffer = io.BytesIO()
    plt.savefig(buffer, format='png')
    plt.close()
    # Convertir la imagen en formato base64
    img_str = base64.b64encode(buffer.getvalue()).decode('utf-8')
    # Insertar la imagen en el archivo HTML
    file.write(f'<img src="data:image/png;base64,{img_str}">')



  

