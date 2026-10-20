Gimnasio Siglo - Sistema de Inscripción
==========================================

VERSIÓN: 1.0 - Completado
FECHA: Octubre 2026
AUTOR: Juan Cuevas

COMPONENTES IMPLEMENTADOS:
==========================
✓ Cliente.cs - Estructura de datos de cliente
✓ GestorClientes.cs - Gestor de array y persistencia
✓ frmInscripcion.cs - Formulario de inscripción
✓ frmBuscar.cs - Formulario de búsqueda
✓ Program.cs - Punto de entrada actualizado

CARACTERÍSTICAS PRINCIPALES:
============================
- Array de 100 clientes máximo
- Persistencia en archivo datos.txt
- Búsqueda por nombre, plan y rango de edad
- Reportes de ingresos por plan y total
- Edad promedio de clientes
- Interfaz mejorada con emojis
- Validaciones completas

VALIDACIONES IMPLEMENTADAS:
============================
- Edad mínima: 14 años
- Meses: entre 1 y 12
- Nombre: convertido a mayúsculas
- Campos numéricos: solo dígitos

CÁLCULO DE COSTOS:
==================
1. Subtotal = (Plan + Casillero) x Meses
2. Descuento por edad/estudiante:
   - Menores de 18: 25%
   - 65 años o más: 30%
   - Estudiante: 15%
3. Descuento/Recargo por forma de pago:
   - Efectivo: -10%
   - Tarjeta 1 cuota: sin recargo
   - Tarjeta 3 cuotas: +10%
   - Tarjeta 6 cuotas: +20%

ARCHIVOS GENERADOS:
===================
- datos.txt: Almacena registros de clientes
- Formato: CSV con pipes (|) como delimitador

ESTADO: COMPLETADO Y LISTO PARA USAR
