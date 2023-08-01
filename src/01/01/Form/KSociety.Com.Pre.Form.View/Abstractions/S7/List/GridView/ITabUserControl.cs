namespace KSociety.Com.Pre.Form.View.Abstractions.S7.List.GridView;

public interface ITabUserControl
{
    IS7Connection GetS7Connection();

    IS7Tag GetS7Tag();
}