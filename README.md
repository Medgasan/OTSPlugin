# OTSPlugin

**OTSPlugin** es una extensión para [KeePass](https://keepass.info/) que permite generar y obtener un enlace de **One-Time Secret** (OTS) a partir de las contraseñas almacenadas en la base de datos de KeePass.

## Características

-   Generación de enlaces de OTS directamente desde KeePass.
-   Compatibilidad con las credenciales almacenadas en el gestor.
-   Simplifica el intercambio seguro de contraseñas de un solo uso.

## Requisitos

-   **KeePass**: Versión 2.x
-   **.NET Framework**: 4.6 o superior

## Instalación

1.  Descarga el archivo DLL del plugin.
2.  Copia el archivo en la carpeta de plugins de KeePass (`C:\Program Files (x86)\KeePass Password Safe 2\Plugins`).
3.  Reinicia KeePass para cargar la extensión.

## Uso

1.  Selecciona una entrada en KeePass.
2.  Usa la opción del menú contextual "Get OneTimeSecret URL from Password".
3.  Comparte el enlace de un solo uso generado para transmitir la contraseña de manera segura.

## Contribuciones

Las mejoras y sugerencias son bienvenidas. Abre un **issue** o envía un **pull request** en el repositorio.

## Licencia

Este proyecto está licenciado bajo la **Apache 2.0 License**.
