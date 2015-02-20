<%@ Page Title="О программе" Language="C#" MasterPageFile="~/Sbyt.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="Sbyt.About" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<div id="ResultReportText">

Данное приложение было разработано и тестировалось при использовании следующих программных продуктов:<br />
<br />

1. OS: Microsoft Windows XP Service Pack 3.0; Windows 7 sp 1.0<br />
2. Microsoft Visual Studio 2010;<br />
3. Microsoft .NET Framework 2.0, 4.0;<br />
4. Oracle 10;<br />
5. Google chrome 16.0.912.77;<br />
<br />
<br />

При первоначальном разворачивании приложения на веб сервере необходимо выполнение условий:<br />
<br />
1.Имя БД ORACLE: OIK;<br />
2.Создать пользователей и пространства ORACLE: sbyt; uzdasbyt; stolbsbyt; nesvsbyt; klecksbyt; dergsbyt.<br />
3.Пароль:1;<br />
4. Сервер с веб сервером: Passport;<br />
5. Веб сервер: UltiDevCassiniWS;<br />
6. Желательна периодическая (раз в месяц) чистка лог файлов. Они расположены в папке: \\passport\C\sbyt\Logs\<br />
7. На D диске компьютера с веб сервером создать группу папок: (SBYT), вложенные в нее (DOWNLOAD и UPLOAD), вложенные в UPLOAD (DERG, NESV, KLECK,UZDA,STOLB)<br />
<br />
Настройки имя БД и пароль могут быть изменены в файле Web.config. Имя пользователя sbyt менять не рекомендуется,
т.к. участвует при формировании запроса к БД.<br />

</div>
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />

<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />
<br />


</asp:Content>
