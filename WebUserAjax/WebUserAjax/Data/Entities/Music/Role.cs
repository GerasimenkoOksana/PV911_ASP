namespace WebUserAjax.Data.Entities.Music
{
    public class Role
    {
        public int id { get; set; }

        public string roleName { get; set; }

        //у роли нет коллекции музыкантов потому что  роли не нужно знать кто на чем играет
    }
}