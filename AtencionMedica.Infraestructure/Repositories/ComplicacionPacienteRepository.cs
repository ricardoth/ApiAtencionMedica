namespace AtencionMedica.Infraestructure.Repositories
{
    public class ComplicacionPacienteRepository : IComplicacionPacienteRepository
    {
        private readonly AtencionMedicaContext _context;
        public ComplicacionPacienteRepository(AtencionMedicaContext context)
        {
            _context = context;
        }

        public async Task<ICollection<ComplicacionPaciente>> GetAll()
        {
            return await _context.ComplicacionPacientes
                .Include(p => p.Paciente)
                .Include(c => c.Complicacion)
                .ToListAsync();
        }

        public async Task<ComplicacionPaciente?> GetById(int id)
        {
            return await _context.ComplicacionPacientes
                .Include(p => p.Paciente)
                .Include(c => c.Complicacion)
                .Where(cp => cp.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task Add(ComplicacionPaciente entity)
        {
            await _context.ComplicacionPacientes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(ComplicacionPaciente entity)
        {
            _context.ComplicacionPacientes.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is null)
                return false;

            entity.EsActivo = false;
            _context.ComplicacionPacientes.Update(entity);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
