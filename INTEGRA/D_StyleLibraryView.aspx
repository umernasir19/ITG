<%@ Page Language="vb" MasterPageFile="~/DeversaMaster.master" AutoEventWireup="false"
    CodeBehind="D_StyleLibraryView.aspx.vb" Inherits="Integra.D_StyleLibraryView" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">

jQuery(document).ready(function($){

	$('#image1').addimagezoom({ // single image zoom
		zoomrange: [3, 10],
		magnifiersize: [300,300],
		magnifierpos: 'right',
		cursorshade: true,
		largeimage: 'hayden.jpg' //<-- No comma after last option!
	})


	$('#image2').addimagezoom() // single image zoom with default options
	
	$('#multizoom1').addimagezoom({ // multi-zoom: options same as for previous Featured Image Zoomer's addimagezoom unless noted as '- new'
		descArea: '#description', // description selector (optional - but required if descriptions are used) - new
		speed: 1500, // duration of fade in for new zoomable images (in milliseconds, optional) - new
		descpos: true, // if set to true - description position follows image position at a set distance, defaults to false (optional) - new
		imagevertcenter: true, // zoomable image centers vertically in its container (optional) - new
		magvertcenter: true, // magnified area centers vertically in relation to the zoomable image (optional) - new
		zoomrange: [3, 10],
		magnifiersize: [250,250],
		magnifierpos: 'right',
		cursorshadecolor: '#fdffd5',
		cursorshade: true //<-- No comma after last option!
	});
	
	$('#multizoom2').addimagezoom({ // multi-zoom: options same as for previous Featured Image Zoomer's addimagezoom unless noted as '- new'
		descArea: '#description2', // description selector (optional - but required if descriptions are used) - new
		disablewheel: true // even without variable zoom, mousewheel will not shift image position while mouse is over image (optional) - new
				//^-- No comma after last option!	
	});
	
})

jQuery(document).ready(function($){ 
 $(' #image1 ').addimagezoom({ 
   zoomrange: [3, 10], 
   magnifiersize: [300,300], 
 // additional options 
 }) 
})
    </script>
    <table width="100%" style="background-color:#dce2e4;">
        <tr>
            <td>
                <b>
                <div class="style_name" >
                    <asp:Label ID="lblStyle" runat="server"></asp:Label>
                    </div>
                </b>
            </td>
        </tr>
        <tr style="height: 20px">
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <div class="big_image">
                    <asp:Image ID="imgFornt"   runat="server" Style="width: 250px; height: 338px;border:2px solid #333333;margin-left: 45px;" /></div>
            </td>
            <td>
                <table>
                    <tr>
                        <td>
                            <b>
                                <div class="form_area">
                                    <div class="txtbox_area" style="height: 120px">
                                        <div class="txt_form">
                                            Description:</div>
                                        <div class="txt_box">
                                            <form id="form1" name="form1" method="post" action="">
                                            <label>
                                                <asp:TextBox ID="txtDiscription" ReadOnly="true" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </label>
                                            </form>
                                        </div>
                                    </div>
                                    <div class="txtbox_area">
                                        <div class="txt_form">
                                            Categeory:</div>
                                        <div class="txt_box">
                                            <asp:TextBox ID="txtCategory" style="width:500px; height:20px;" ReadOnly="true" runat="server"></asp:TextBox></div>
                                    </div>
                                    <div class="txtbox_area">
                                        <div class="txt_form">
                                            Material:</div>
                                        <div class="txt_box">
                                            <asp:TextBox ID="txtMaterial" style="width:500px; height:20px;" ReadOnly="true" runat="server"></asp:TextBox></div>
                                    </div>
                                    <div class="txtbox_area">
                                        <div class="txt_form">
                                            Price:</div>
                                        <div class="txt_box">
                                            <asp:TextBox ID="txtPrice" style="width:500px; height:20px;" ReadOnly="true" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="txtbox_area">
                                        <div class="txt_form">
                                            MOQ:</div>
                                        <div class="txt_box">
                                            <asp:TextBox ID="txtMOQ" style="width:500px; height:20px;" ReadOnly="true" runat="server"></asp:TextBox></div>
                                    </div>
                                </div>
                            </b>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="lnkForntThumbnail" runat="server"> <asp:Image ID="imgForntThumbnail" style="border:2px solid #333333; margin-left: 5px;" runat="server" /></asp:LinkButton>
                <asp:LinkButton ID="lnkBackThumbnail" runat="server"> <asp:Image ID="imgBackThumbnail" style="border:2px solid #333333;" runat="server" />
                </asp:LinkButton>
                <asp:LinkButton ID="lnkLeftThumbnail" runat="server"> <asp:Image ID="imgLeftThumbnail" style="border:2px solid #333333;" runat="server" />
                </asp:LinkButton>
                <asp:LinkButton ID="lnkRightThumbnail" runat="server"> <asp:Image ID="imgRightThumbnail" style="border:2px solid #333333;" runat="server" />
                </asp:LinkButton>
            </td>
        </tr>
    </table>
</asp:Content>
