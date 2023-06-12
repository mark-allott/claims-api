namespace ClaimsApi.Data.DTO
{
	public abstract class AbstractDto<TEntity> where TEntity : class
	{
		#region Ctor

		protected AbstractDto()
		{
		}

		protected AbstractDto(TEntity entity)
		{
		}

		#endregion Ctor

		protected abstract void SetValuesFromEntity(TEntity entity);
	}
}