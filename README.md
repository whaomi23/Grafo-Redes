# Grafo_Redes

## Descripción

Grafo_Redes es una aplicación de escritorio desarrollada en **C# con Windows Forms** que permite crear, visualizar y analizar grafos de forma interactiva. El usuario puede agregar nodos, establecer conexiones entre ellos, asignar pesos a las aristas y generar automáticamente la matriz de adyacencia del grafo.

La herramienta está orientada al aprendizaje de estructuras de datos, teoría de grafos, redes de comunicación y algoritmos de representación gráfica.

---

## Características

* Creación dinámica de nodos mediante clic del mouse.
* Asignación personalizada de nombres a cada nodo.
* Generación automática de colores para los nodos.
* Creación de conexiones entre vértices.
* Asignación de pesos a las aristas.
* Visualización gráfica de nodos y conexiones.
* Soporte para grafos dirigidos y no dirigidos.
* Generación de matrices de adyacencia.
* Eliminación de nodos.
* Limpieza completa del grafo.
* Registro de nodos creados.

---

## Tecnologías Utilizadas

* C#
* .NET Framework
* Windows Forms
* GDI+ Graphics
* Programación Orientada a Objetos (POO)

---

## Funcionamiento

### Crear Nodos

1. Hacer clic dentro del área de dibujo.
2. Introducir el nombre del nodo.
3. El sistema crea automáticamente:

   * Número identificador.
   * Color aleatorio.
   * Posición X,Y.

Ejemplo:

```text
Nodo A
Nodo B
Nodo C
```

---

### Crear Conexiones

1. Seleccionar dos nodos desde los ComboBox.
2. Ingresar el peso de la conexión.
3. El sistema dibuja una flecha entre ambos nodos.

Ejemplo:

```text
A → B (5)
B → C (3)
C → A (2)
```

---

### Grafo Dirigido

Las conexiones tienen dirección.

Ejemplo:

```text
A → B
```

No implica:

```text
B → A
```

---

### Grafo No Dirigido

Las conexiones representan relaciones bidireccionales.

Ejemplo:

```text
A ↔ B
```

---

### Matriz de Adyacencia

El sistema puede generar automáticamente la matriz de adyacencia del grafo.

Ejemplo:

```text
     A  B  C

A    0  1  0
B    0  0  1
C    1  0  0
```

---

## Estructura del Proyecto

```text
Grafo_Redes/
│
├── Form1.cs
├── Form1.Designer.cs
├── Nodo.cs
├── Program.cs
├── Properties/
└── Resources/
```

---

## Componentes Principales

### Clase Nodo

Representa un vértice dentro del grafo.

Propiedades:

* Número identificador.
* Nombre.
* Color.
* Posición X.
* Posición Y.
* Lista de conexiones salientes.

---

### Clase Conexion

Representa una arista entre dos nodos.

Propiedades:

* Nodo destino.
* Peso.

---

### Dibujo del Grafo

Se utiliza el evento:

```csharp
CONSOLA_GRAFO_Paint()
```

para renderizar:

* Nodos.
* Flechas.
* Etiquetas.
* Pesos.

---

## Funcionalidades Implementadas

* Agregar nodos.
* Eliminar nodos.
* Conectar nodos.
* Dibujar grafos.
* Mostrar pesos.
* Generar matriz de adyacencia.
* Cambiar entre grafo dirigido y no dirigido.
* Limpiar grafo completo.

---

## Aplicaciones

Este proyecto puede utilizarse para:

* Teoría de Grafos.
* Redes de Computadoras.
* Algoritmos de Búsqueda.
* Inteligencia Artificial.
* Modelado de Redes.
* Sistemas de Transporte.
* Simulación de Conexiones.

---

## Objetivo del Proyecto

Proporcionar una herramienta visual para la construcción y análisis de grafos, facilitando el aprendizaje de estructuras de datos y la representación de redes mediante una interfaz gráfica interactiva.

---

## Autor

Proyecto desarrollado en C# utilizando Windows Forms para la representación gráfica y manipulación interactiva de grafos dirigidos y no dirigidos.
