The project is avialable to try out in Itch io : https://orwinik.itch.io/homeass-mocart

To run the project on a local machine you need to :

1. Clone this repository from GitHub
2. Open the project in Unity
3. Add the packages used : in this project i have used Dotween for animations as well as 2 asset packs from the unity asset store which you will need to get to run the project locally.
    https://assetstore.unity.com/packages/3d/props/tdg-storage-solutions-252198
    https://assetstore.unity.com/packages/3d/props/shelves01-pack-289927
4. Build and run the project.


As for the code itself i have one script called ServerManager for managing the data taken from the server as well as showing the shelf and the products on it aswell as changing the values on the shelf.
The script also controls the platform managment from PC and Mobile and the confirmation and error messeges.
Additionally i have another script that uses dotween for the Lunch animations. 

* The input fields in unity dont open up the keyboard in mobile on browser , there are somefixes to it which could be adding a manual java script object to 
  manually open the keyboard or creating/importing a keyboard to the unity project.
