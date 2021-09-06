<!-- PROJECT SHIELDS -->
<!--
*** I'm usiang markdown "reference style" links for readability.
*** Reference links are enclosed in brackets [ ] instead of parentheses ( ).
*** See the bottom of this document for the declaration of the reference variables
*** for contributors-url, forks-url, etc. This is an optional, concise syntax you may use.
*** https://www.markdownguide.org/basic-syntax/#reference-style-links
-->
[![Contributors][contributors-shield]][contributors-url]
[![Forks][forks-shield]][forks-url]
[![Stargazers][stars-shield]][stars-url]
[![Issues][issues-shield]][issues-url]
[![MIT License][license-shield]][license-url]
[![LinkedIn][linkedin-shield]][linkedin-url]



<!-- PROJECT LOGO -->
<br />
<p align="center">
  <a href="https://github.com/github_shaishulman/MailboxAngel">
    <img src="Graphics/logo.gif" alt="Logo">
  </a>

  <h3 align="center">TrendTrackr App</h3>

  <p align="center">
    MS Outlook add-in with functionalities for handling multiple mail folders, suggestions for moving mail items into folders and reorganizing attachments from the compose window.
    <!--
    <br />
    <a href="https://github.com/ShaiShulman/MailboxAngel"><strong>Explore the docs »</strong></a>
    <br />
    <br />
    <a href="https://github.com/ShaiShulman/MailboxAngel">View Demo</a>
    ·
    <a href="https://github.com/ShaiShulman/MailboxAngel/issues">Report Bug</a>
    ·
    <a href="https://github.com/ShaiShulman/MailboxAngel/issues">Request Feature</a>
    -->
  </p>
</p>



<!-- TABLE OF CONTENTS -->
<details open="open">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li>
      <a href="#about-the-project">About The Project</a>
    </li>
    <li>
      <a href="#getting-started">Getting Started</a>
      <ul>
        <li><a href="#prerequisites">Prerequisites</a></li>
        <li><a href="#installation">Installation</a></li>
      </ul>
    </li>
    <li>
        <a href="#functionalities">Functionalities</a>
        <ul>
            <li><a href="#searchfolder">Search folder by name</a></li>
            <li><a href="#folderHistory">Folder history</a></li>
            <li><a href="#movePrevNext">Scroll between same folders in seperate PSTs</a></li>
            <li><a href="#filingSuggestion">Mail filing suggestion</a></li>
            <li><a href="#attachmentHelper">Attachment manager</a></li>
        </ul>
    </li>
    <!--<li><a href="#roadmap">Roadmap</a></li>
    <li><a href="#license">License</a></li>
    <li><a href="#contact">Contact</a></li>
    <li><a href="#acknowledgements">Acknowledgements</a></li>
  </ol>
</details>



<!-- ABOUT THE PROJECT -->
## About The Project

![Product Name Screen Shot][product-screenshot]

* Find folder by typing the first letters of its name
* Move between folders with same name on different PSTs (next/previous)
* Display list of recenty used folders
* Show suggestion one where to file a mail items based on recent folders, other items in the conversation, and otehr items with the same sender
* Attachment helper, allowing attachments manipulations directly from the composing windows:
     - Change file name of attachments
     - Change order of attachments
     - Accept all changes in an attachment (for Word documents)
     - Create zip file with the attachments and attach to the mail item  

<!-- GETTING STARTED -->
## Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

This addin is known to work with Microsoft Outlook 2013 and above. 
As the solution was built with MS .Net, it will require .Net Runtime to be installed 

### Installation

1. Open MailboxAngel.sln with MS Visual Studio and build the entire solution. 

2. MailBox Angel will be added to the list of available Outlook addins. Select the addin to activate it.

<!-- FUNCTIONALITY -->

## Functionality

### Search Folder by Name

* You can search for a folder by part of its name by entering a string in the <u>Search</u> box
* A new window will be opened with the matching folders and their respective subfolders
* You can select folder from the list to change the current folder.
* You can go back to the previous folder by clicking <u>Undo</u>.

### Folder History

* The addin tracks the last folders you are using (either by exploring or moving items to them).
* You can view the list of last used folders by clicking <u>History</u> on the ribbon and go to any of these folders.
* You can designate the current folder to contantly be included on the or to never incluide on the list by click <u>Always</u> or <u>Never</u> at the bottom of the History menu

### Scroll Between Folders in Different PSTs

* If you have folders with same structure in different PSTs, you can scroll between the current folder in your mailbox and the same folder in the connected PSTs by clicking <u>Next</u> and <u>Prev</u>.
* The addin will search for the same folder structure in the next/previous connected PST and will make the folder with the same name the displayed folder. 
* If the add-in does not find a folder with the same name, it will move to the next PST or mailbox.

### Mail Filing Suggestions

* The addin tracks where evey email from each sender is moved from the inbox. 
* By clicking <u>Suggestions</u> it can provide suggested folders to move the specific email, based on:
  - Suggestion: previous emails with the same sender
  - Convesation: where other email items from the same conversation are located
  - History: previously used folders.
* If the conversation header rather than a specific email in teh conversation are selected, all emails in the specific conversation located in the current folder will be moved.

### Attachments Manager

* The Attachment Manager allows the user complete control of an email's attachment, directly from the new email composition window.
* To start, click <u>Attachment Manager</u> from the Compose window, and the Attachment window will loan the existing attachment.
* For each attachment, you could:
  - Rename the attachment as it will appear to the recepient
  - Delete the attachment
  - Reorder the attachments by drag and drop or clicking the <u>Up</u> and <u>Down</u> buttons
  - Approve all marked changes (MS Word documents only)
  - Add certain attachments to a zip file thatwill be automatically added to the mail item
* You can also add numbers to all attachment names and add a list of attachments to the email body (in case you want to add comments for each file).
* After you're done, click <u>Apply</u> to process the changes and update the mail item. 

<!-- LICENSE -->
## License

Distributed under the MIT License. See `LICENSE` for more information.



<!-- CONTACT -->
## Contact

Shai Shulman - [@shaishulman](https://twitter.com/shaishulman) - shai.shulman@gmail.com

Project Link: [https://github.com/github_shaishulman/MailboxAngel](https://github.com/github_shaishulman/MailboxAngel)



<!-- MARKDOWN LINKS & IMAGES -->
<!-- https://www.markdownguide.org/basic-syntax/#reference-style-links -->
[contributors-shield]: https://img.shields.io/github/contributors/ShaiShulman/MailboxAngel.svg?style=for-the-badge
[contributors-url]: https://github.com/ShaiShulman/MailboxAngel/graphs/contributors
[forks-shield]: https://img.shields.io/github/forks/ShaiShulman/MailboxAngel.svg?style=for-the-badge
[forks-url]: https://github.com/ShaiShulman/MailboxAngel/network/members
[stars-shield]: https://img.shields.io/github/stars/ShaiShulman/MailboxAngel.svg?style=for-the-badge
[stars-url]: https://github.com/ShaiShulman/MailboxAngel/stargazers
[issues-shield]: https://img.shields.io/github/issues/ShaiShulman/MailboxAngel.svg?style=for-the-badge
[issues-url]: https://github.com/ShaiShulman/MailboxAngel/issues
[license-shield]: https://img.shields.io/github/license/ShaiShulman/MailboxAngel.svg?style=for-the-badge
[license-url]: https://github.com/ShaiShulman/MailboxAngel/blob/master/LICENSE.txt
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=for-the-badge&logo=linkedin&colorB=555
[linkedin-url]: https://linkedin.com/in/shshulman/
[product-screenshot]: Graphics/Full_ribbon_screenshot.png