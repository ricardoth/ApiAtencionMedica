﻿namespace AtencionMedica.Infraestructure.Repositories
{
    public class ComplicacionPacienteRepository : IComplicacionPacienteRepository
    {
        private readonly AtencionMedicaContext _context;
        private readonly IUnitOfWork _unitOfWork;

        public ComplicacionPacienteRepository(AtencionMedicaContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
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
            entity.FecCreacion = DateTime.Now;
            await _context.ComplicacionPacientes.AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Update(ComplicacionPaciente entity)
        {
            entity.FecActualizacion = DateTime.Now;
            _context.ComplicacionPacientes.Update(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await GetById(id);
            if (entity is null)
                return false;

            entity.EsActivo = false;
            entity.FecActualizacion = DateTime.Now;
            _context.ComplicacionPacientes.Update(entity);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}
