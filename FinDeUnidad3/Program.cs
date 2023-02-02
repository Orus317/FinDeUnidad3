using AppElecciones;
using EstructurasDeDatos;

#region Partidos predeterminados
// Falta implementar una verificación de representantes por lo que se usarán datos fútiles
CArbolPartido ArbolPartido = new();
ArbolPartido.Agregar(new CPartido("P01", "Partido1", "R001", 1200, 900));
ArbolPartido.Agregar(new CPartido("P01", "Partido2", "R002", 900, 800));
ArbolPartido.Agregar(new CPartido("P03", "Partido3", "R003", 1800, 1700));
ArbolPartido.Agregar(new CPartido("P04", "Partido4", "R004", 1000, 700));
ArbolPartido.Agregar(new CPartido("P05", "Partido5", "R005", 100, 40));
ArbolPartido.Agregar(new CPartido("P06", "Partido6", "R006", 700, 400));
ArbolPartido.Agregar(new CPartido("P07", "Partido7", "R007", 600, 200));
ArbolPartido.Agregar(new CPartido("P08", "Partido8", "R008", 100, 100));
ArbolPartido.Agregar(new CPartido("P09", "Partido9", "R009", 2000, 1200));
ArbolPartido.Agregar(new CPartido("P010", "Partid10", "R010", 1200, 1100));
#endregion
