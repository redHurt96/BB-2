using InstantGamesBridge;
using InstantGamesBridge.Modules.Advertisement;
using UnityEngine;
using UnityEngine.UI;

namespace Examples
{
    public class AdvertisementPanel : MonoBehaviour
    {
        [SerializeField] private Text _interstitialState;

        [SerializeField] private Text _rewardedState;
        
        [SerializeField] private Text _bannerSupported;
        
        [SerializeField] private Text _bannerShowing;

        [SerializeField] private InputField _minimumDelayBetweenInterstitial;

        [SerializeField] private Button _setMinimumDelayBetweenInterstitialButton;

        [SerializeField] private Button _showBannerButton;
        
        [SerializeField] private Button _hideBannerButton;
        
        [SerializeField] private Button _showInterstitialButton;

        [SerializeField] private Toggle _showInterstitialIgnoreDelayToggle;

        [SerializeField] private Button _showRewardedButton;

        [SerializeField] private GameObject _overlay;


        private void Start()
        {
            Bridge.advertisement.interstitialStateChanged += OnInterstitialStateChanged;
            Bridge.advertisement.rewardedStateChanged += OnRewardedStateChanged;
            
            _setMinimumDelayBetweenInterstitialButton.onClick.AddListener(OnSetMinimumDelayBetweenInterstitialButtonClicked);
            _showBannerButton.onClick.AddListener(OnShowBannerButtonClicked);
            _hideBannerButton.onClick.AddListener(OnHideBannerButtonClicked);
            _showInterstitialButton.onClick.AddListener(OnShowInterstitialButtonClicked);
            _showRewardedButton.onClick.AddListener(OnShowRewardedButtonClicked);

            _bannerSupported.text = $"Is Banner Supported: { Bridge.advertisement.isBannerSupported }";
            UpdateBannerShowing();

            OnInterstitialStateChanged(Bridge.advertisement.interstitialState);
            OnRewardedStateChanged(Bridge.advertisement.rewardedState);
            UpdateMinimumDelayBetweenInterstitial();
        }

        private void OnDestroy()
        {
            if (Bridge.instance != null)
            {
                Bridge.advertisement.interstitialStateChanged -= OnInterstitialStateChanged;
                Bridge.advertisement.rewardedStateChanged -= OnRewardedStateChanged;
            }
        }


        private void OnInterstitialStateChanged(InterstitialState state)
        {
            _interstitialState.text = $"Interstitial State: { state }";
        }

        private void OnRewardedStateChanged(RewardedState state)
        {
            _rewardedState.text = $"Rewarded State: { state }";
        }

        private void OnSetMinimumDelayBetweenInterstitialButtonClicked()
        {
            int.TryParse(_minimumDelayBetweenInterstitial.text, out var seconds);
            Bridge.advertisement.SetMinimumDelayBetweenInterstitial(seconds);
            UpdateMinimumDelayBetweenInterstitial();
        }
        
        private void OnShowBannerButtonClicked()
        {
            _overlay.SetActive(true);
            
            Bridge.advertisement.ShowBanner(
                success =>
                {
                    UpdateBannerShowing();
                    _overlay.SetActive(false);
                },
                new ShowBannerVkOptions(VkBannerPosition.Bottom));
        }

        private void OnHideBannerButtonClicked()
        {
            _overlay.SetActive(true);
            
            Bridge.advertisement.HideBanner(
                success =>
                {
                    UpdateBannerShowing();
                    _overlay.SetActive(false);
                });
        }

        private void OnShowInterstitialButtonClicked()
        {
            _overlay.SetActive(true);

            var ignoreDelay = _showInterstitialIgnoreDelayToggle.isOn;

            // Common variant
            Bridge.advertisement.ShowInterstitial(
                ignoreDelay,
                success =>
                {
                    _overlay.SetActive(false);
                });

            // Platform specific variant
            /*Bridge.advertisement.ShowInterstitial(
                success => { _overlay.SetActive(false); },
                new ShowInterstitialVkOptions(ignoreDelay),
                new ShowInterstitialYandexOptions(ignoreDelay));*/
        }

        private void OnShowRewardedButtonClicked()
        {
            _overlay.SetActive(true);
            Bridge.advertisement.ShowRewarded(success => { _overlay.SetActive(false); });
        }

        private void UpdateMinimumDelayBetweenInterstitial()
        {
            _minimumDelayBetweenInterstitial.text = Bridge.advertisement.minimumDelayBetweenInterstitial.ToString();
        }

        private void UpdateBannerShowing()
        {
            _bannerShowing.text = $"Is Banner Showing: { Bridge.advertisement.isBannerShowing }";
        }
    }
}