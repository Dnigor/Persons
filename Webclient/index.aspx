﻿<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">


<script src="JScript.js" type="text/javascript" language="javascript"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
       
       
       #b0,#b1,#b2,#b3,#b4,#b5,#b6,#b7,#b8,#b9,
       #b10,#b11,#b12,#b13,#b14,#b15,#b16,#b17,#b18,#b19,
       #b20,#b21,#b22,#b23,#b24,#b25,#b26,#b27,#b28,#b29,
       #b30,#b31,#b32,#b33,#b34,#b35,#b36,#b37,#b38,#b39,
       #b40,#b41,#b42,#b43,#b44,#b45,#b46,#b47,#b48,#b49,
       #b50,#b51,#b52,#b53,#b54,#b55,#b56,#b57,#b58,#b59,
       #b60,#b61,#b62,#b63,#b64,#b65,#b66,#b67,#b68,#b69,
       #b70,#b71,#b72,#b73,#b74,#b75,#b76,#b77,#b78,#b79,
       #b80,#b81,#b82,#b83,#b84,#b85,#b86,#b87,#b88,#b89,
       #b90,#b91,#b92,#b93,#b94,#b95,#b96,#b97,#b98,#b99,
       #b100,#b101,#b102,#b103,#b104,#b105,#b106,#b107,#b108,#b109,
       #b110,#b111,#b112,#b113,#b114,#b115,#b116,#b117,#b118,#b119,
       #b120,#b121,#b122,#b123,#b124,#b125,#b126,#b127,#b128,#b129,
       #b130,#b131,#b132,#b133,#b134,#b135,#b136,#b137,#b138,#b139,
       #b140,#b141,#b142,#b143,#b144,#b145,#b146,#b147,#b148,#b149,
       #b150,#b151,#b152,#b153,#b154,#b155,#b156,#b157,#b158,#b159,
       #b160,#b161,#b162,#b163,#b164,#b165,#b166,#b167,#b168,#b169,
       #b170,#b171,#b172,#b173,#b174,#b175,#b176,#b177,#b178,#b179,
       #b180,#b181,#b182,#b183,#b184,#b185,#b186,#b187,#b188,#b189,
       #b190,#b191,#b192,#b193,#b194,#b195,#b196,#b197,#b198,#b199 
        {
            height: 30px;
            width: 30px; 
        }
       
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScriptManager1" runat="server">
         <Services>
            <asp:ServiceReference Path="http://localhost:12417/DBService.svc" />
        </Services>

        </asp:ScriptManager>
    
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            
            <br />
            <input type="button" id="Get" value="Get" onclick="Get_Click()" />
         
         
            <br />
       
     
        <div id="Record"></div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
