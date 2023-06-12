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
			// ReSharper disable once VirtualMemberCallInConstructor
			SetValuesFromEntity(entity);
		}

		#endregion Ctor

		protected virtual void SetValuesFromEntity(TEntity entity)
		{
		}
	}
}