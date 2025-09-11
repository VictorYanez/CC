$(function ()
{
    $("[id*=txt_Fecha]").datepicker(
        {
            dateFormat: 'dd/mm/yy',
            changeMonth: true,
            changeYear: true,
            yearRange: '1950:2100'  
        }
    );
}
);