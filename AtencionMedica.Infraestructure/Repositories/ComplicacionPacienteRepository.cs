namespace AtencionMedica.Infraestructure.Repositories
{
    public class ComplicacionPacienteRepository : IComplicacionPacienteRepository
    {
        private readonly AtencionMedicaContext _context;
        public ComplicacionPacienteRepository(AtencionMedicaContext context)
        {
            _context = context;       
        }

        public Task Add(ComplicacionPaciente entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ComplicacionPaciente> GetComplicacionPaciente(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<ComplicacionPaciente>> GetComplicacionPacientes()
        {
            return await _context.ComplicacionPacientes
                .Include(p => p.Paciente)
                .Include(c => c.Complicacion)
                .ToListAsync();
        }

        public void Update(ComplicacionPaciente entity)
        {
            throw new NotImplementedException();
        }
    }
}
