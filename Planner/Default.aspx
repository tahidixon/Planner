<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Planner._Default" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
        //Day Panel
        <div class="col-md-4">
            <div class="panel-group">
                <div class="panel panel-primary">
                    <div class="panel-heading">
                        <h4 class="panel-title">Day overview</h4>
                    </div>
                </div>
                <div class="panel-body">
                    <div class="panel-group" id="accordion" style="height:500px; overflow-y:scroll;" >
                        <asp:Repeater ID="rptTaskPanel" runat="server">
                            <ItemTemplate>
                                <div class="panel panel-default" runat="server">
                                    <div class="panel-heading" >
                                        <h4 class="panel-title" style='<%# "font-size:14px; color:#ffffff; background-color:#" + Eval("Category") + "; border-color:#" + Eval("Category") + ";"%>' >
                                            <a data-toggle="collapse" data-parent="#accordion" href='<%# "#collapse_" + Eval("TaskID") %>' runat="server" OnItemCommand="rptTaskPanel_setActiveElement" CommandArgument='<%# Eval("TaskID") %>'>
                                                <asp:Label runat="server" ID="taskName" Text='<%# Eval("Name") %>'></asp:Label>
                                                <asp:Label runat="server" class="pull-right" Style="overflow: hidden; white-space: nowrap;" ID="taskCreated" Text='<%# "Priority: " + Eval("Priority") %>'></asp:Label>
                                            </a>
                                        </h4>
                                    </div>
                                    <div id='<%# "collapse_" + Eval("TaskID") %>' class="panel-collapse collapse">
                                        <div runat="server" class="panel-body" >
                                            <p runat="server" text='<%# Eval("Notes") %>'></p>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <div class="panel-footer">
                    <div class="navbar">
                    </div>
                 </div>
                    <div class="modal fade" id="addTaskModal">
                        <div class="modal-dialog">
                                    <div class="modal-content">
                                        <div class="modal-header text-center">
                                            <button type="button" class="close" data-dismiss="modal">&times;</button>
                                            <h4 class="modal-title">Add a task</h4>
                                            <div class="modal-body text-center">
                                                <h2>Alright, chap!</h2>
                                                <asp:Label ID="lblTaskName" runat="server">Name of task:</asp:Label>
                                                <asp:TextBox ID="txtTaskName" runat="server" CssClass="form-control center-block"></asp:TextBox>
                                                <br />
                                                <asp:Label ID="lblTaskCategory" runat="server">Category:</asp:Label>
                                                <asp:DropDownList ID="ddCategory" runat="server" CssClass="center-block">
                                                </asp:DropDownList>
                                                <br />
                                                <asp:Label ID="lblTaskNotes" runat="server">Notes:</asp:Label>
                                                <asp:TextBox ID="txtTaskNotes" runat="server" CssClass="form-control center-block" TextMode="MultiLine"></asp:TextBox>
                                                <br />
                                                
                                            </div>
                                        </div>
                                    </div>
                        </div>
                        
                    </div>
                    <div class="modal fade" id="sortTaskModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header text-center">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Sort tasks</h4>
                                    <h2>Alright, chap!</h2>
                                    Categories to view:<br />
                                    <asp:CheckBoxList ID="btnDaySort_Categories" runat="server" DataTextField="Name" DataValueField="CategoryID" CssClass="center-block">
                                    </asp:CheckBoxList>
                                    <br />
                                Sort tasks by:<asp:DropDownList ID="btnDaySort_ddSort" runat="server">
                                    <asp:ListItem Value="0">Name: A to Z</asp:ListItem>
                                    <asp:ListItem Value="1">Name: Z to A</asp:ListItem>
                                    <asp:ListItem Value="1">Date created: Oldest first</asp:ListItem>
                                    <asp:ListItem Value="2">Date created: Recent first</asp:ListItem>
                                    <asp:ListItem Value="4">Priority: Lowest first</asp:ListItem>
                                    <asp:ListItem Value="5">Priority: Highest first</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <br />
                                <asp:Button ID="btnDaySort_Confirm" runat="server" Text="Ok" CssClass="btn btn-success center-block" data-dismiss="modal"/>
                                <asp:Button ID="btnDaySort_Cancel" runat="server" Text="Cancel" CssClass="btn btn-default center-block" data-dismiss="modal"/>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="modal fade" id="deleteTaskModal">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header text-center">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Remove Task</h4>
                                    
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
        </div>
        //Week Panel
        <div class="col-md-8">
            <div class="panel-group">
                <div class="panel panel-danger">
                    <div class="panel-heading">
                        <h4 class="panel-title">Week overview</h4>
                    </div>
                </div>
                <div class="panel-body" id="weekBody">
                    
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-4">
            <div class="panel-group">
                <div class="panel panel-warning">
                    <div class="panel-heading">
                        <h4 class="panel-title">Directive</h4>
                    </div>
                </div>
                <div class="panel-body center-block center-text" id="directiveBody">
                    <h3>Current directive:</h3>
                    <br />
                    <asp:Label runat="server" ID="lblCDirective"></asp:Label>
                    <br />
                    <h5>Next directive: </h5><h5 runat="server" ID="lblNDirective"></h5>
                    <br />
                    <h5>At:</h5>
                    <br />
                    <h5 runat="server" id="lblNDirective_deltaTime"></h5>
                </div>
            </div>
        </div>
        <div class="col-md-8">
            <div class="panel-group">
                <div class="panel panel-success">
                    <div class="panel-heading">
                        <h4 class="panel-title">Action panel</h4>
                    </div>
                </div>
                <div class="panel-body" id="actionBody">
                    lorem ipsum
                    <asp:ListBox ID="outBox" runat="server"></asp:ListBox>
                </div>
            </div>
        </div>
        <script>
        $(document).ready(function(){
            $(".dropdown-toggle").dropdown();
        });
        </script>
    </div>
    

</asp:Content>
