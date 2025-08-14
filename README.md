# Image Capture and Analysis Project

This project uses **IDS Peak** for capturing and adjusting images of connectors, clips, etc. 
Users can add text annotations and can also modify focus, exposure, ROI, etc. 
Images are stored in the local storage, while their features can be stored in a database and analyzed for similarity using **EMGU CV** (a .NET wrapper for OpenCV).
**EasyModbusTCP** is integrated for controlling hardware like lights and motor positioning.

## Features
- **Image Capture and Adjustment**: Modify focus, exposure, gain, white-balance and Region of Interest (ROI).
- **Annotation**: Add text descriptions to images.
- **Database Storage**:
  - Save image details and features for future reference.
  - Add details like Name, Type (connector, clip, grommet, or olhal), Color, and Number of Vias when saving images.
  - If the type is "olhal," specify the diameter.
  - Use these parameters to refine search criteria for similar images.
- **Image Similarity**: Find similar images with adjustable thresholds using EMGU CV.
- **Image Size and Quality**:
  - Adjust the image resolution and compression quality. Default image quality is 73 (max. 100). Default image resize factor is 0.5 (max. 1).
  - Save original images without compression if needed (Tools -> Save original image).
- **Search Results**: 
  - View a list of similar images with previews of the closest matches.
  - Search can be sped up by filtering using metadata.
- **File Management**: 
  - Default folder for images can be changed (Tools -> Change default folder).
  - Name acts as the link between images stored locally and features/descriptions stored in the database.
- **Hardware Control**: Control lighting and motor positions via Modbus.

## Shortcuts
- **Ctrl+I**: Open Image Similarity Settings (adjust thresholds).
- **Ctrl+F**: Change default folder for image saving and retrieval.
- **Ctrl+M**: Open Modbus Settings (update IP and Port).
- **Ctrl+D**: Open Database Settings (userid, password, etc.).

## Technologies Used
- **IDS Peak**: For camera control and image capture.
- **EMGU CV**: For image processing and similarity detection.
- **EasyModbusTCP**: For hardware control.

---
